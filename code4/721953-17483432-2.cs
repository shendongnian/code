    public bool IsAirplaneMode()
    {
        bool[] networks = new bool[4] { DeviceNetworkInformation.IsNetworkAvailable, DeviceNetworkInformation.IsCellularDataEnabled, DeviceNetworkInformation.IsCellularDataRoamingEnabled, DeviceNetworkInformation.IsWiFiEnabled };
        return (networks.Count(n => n) < 1);
    }
