    // get a list of all paired devices
    BluetoothDeviceInfo[] paired = localClient.DiscoverDevices(255, false, true, false, false);
    // check every discovered device if it is already paired 
    foreach (BluetoothDeviceInfo device in this.deviceList)
    {
        bool isPaired = false;
        for (int i = 0; i < paired.Length; i++)
        {
            if (device.Equals(paired[i]))
            {
                isPaired = true;
                break;
            }
        }
        // if the device is not paired, pair it!
        if (!isPaired)
        {
            // replace DEVICE_PIN here, synchronous method, but fast
            isPaired = BluetoothSecurity.PairRequest(device.DeviceAddress, DEVICE_PIN);
            if (isPaired)
            {
                // now it is paired
            }
            else
            {
                // pairing failed
            }
        }
    }
