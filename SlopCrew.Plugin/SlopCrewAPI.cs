using System;
using SlopCrew.API;

namespace SlopCrew.Plugin; 

public class SlopCrewAPI : ISlopCrewAPI {
    public int PlayerCount { get; set; }
    public string ServerAddress { get; set; } = Plugin.ConfigAddress.Value;
    public bool Connected { get; set; }
    
    public event Action<int>? OnPlayerCountChanged;
    public event Action? OnConnected;
    public event Action? OnDisconnected;

    internal void UpdatePlayerCount(int count) {
        this.PlayerCount = count;
        this.OnPlayerCountChanged?.Invoke(count);
    }
    
    internal void UpdateConnected(bool connected) {
        this.Connected = connected;
        if (connected) {
            this.OnConnected?.Invoke();
        } else {
            this.OnDisconnected?.Invoke();
        }
    }
}
