    // check if device is paired
    if (device.Authenticated)
    {
        // set pin of device to connect with
        localClient.SetPin(DEVICE_PIN);
        // async connection method
        localClient.BeginConnect(device.DeviceAddress, BluetoothService.SerialPort, new AsyncCallback(Connect), device);
    }
    // callback
    private void Connect(IAsyncResult result)
    {
        if (result.IsCompleted)
        {
            // client is connected now :)
        }
    }
