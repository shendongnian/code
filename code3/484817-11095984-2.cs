    var deviceManager = new DeviceManager();    
    for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
    {
        var deviceName = 
            deviceManager.DeviceInfos[i].Properties["Name"].get_Value().ToString();
        // Is the device a scanner?
        if (deviceManager.DeviceInfos[i].Type == WiaDeviceType.ScannerDeviceType)
        {
            //...etc.
        }
    }
