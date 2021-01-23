    var _remoteDevices = new Dictionary<string, RemoteDevice>();
    
...
    var deviceId = notifyMessage.UUID.Trim().ToLowerInvariant();
    
    RemoteDevice remoteDevice;
    
    if (_remoteDevices.TryGetValue(deviceId, out remoteDevice))
    {
        UpdateDevice(remoteDevice);
    }
    else
    {
        var newDevice = CreateDevice(notifyMessage);
    
        _remoteDevices.Add(deviceId, newDevice);
    }
