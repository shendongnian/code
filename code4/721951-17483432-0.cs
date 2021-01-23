    public bool IsAirplaneMode()
    {
       return DeviceNetworkInformation.IsNetworkAvailable && 
              (DeviceNetworkInformation.IsCellularDataEnabled ||
              DeviceNetworkInformation.IsCellularDataRoamingEnabled ||
              DeviceNetworkInformation.IsWiFiEnabled);
    }
