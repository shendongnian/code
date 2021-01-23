    WifiConfiguration wifiConfiguration = new WifiConfiguration
    {
        Ssid = ssid,
        PreSharedKey = password
    };        
    wifiConfiguration.AllowedKeyManagement.Set((int)KeyManagementType.WpaPsk);            
    wifiConfiguration.AllowedAuthAlgorithms.Set((int)AuthAlgorithmType.Open);
