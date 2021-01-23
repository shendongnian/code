    public static void EnableVideoDrivers(bool enable)
    {
        // every type of device has a hard-coded GUID, put here the one for
        // video drivers
        Guid videoGuid = new Guid("{device GUID}");
        // get this from the properties dialog box of this device in Device Manager
        string instancePath = @"Device Instance Path";
        DeviceHelper.SetDeviceEnabled(videoGuid, instancePath, enable);
    }
