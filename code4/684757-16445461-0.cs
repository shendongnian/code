    SynTP_API.Initialize();
    SynTP_API.Activate();
    DeviceHandle = SynTP_API.FindDevice(new SynConnectionType(), new SynDeviceType(), 0);
    SynTP_Dev.Select(DeviceHandle);
    SynTP_Dev.Activate();  
    SynTP_Dev.OnPacket += SynTP_Dev_OnPacket;
