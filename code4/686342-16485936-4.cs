    /// <summary>
    /// Connects to a remote device.
    /// </summary>
    /// <param name="rd">Remote device that the adapter is supposed to connect to.</param>
    public void DoConnection(IRemoteBTDevice rd)
    {
        BluetoothAddress remoteAddress = new BluetoothAddress(Convert.ToInt64(rd.Id, 16));
        BluetoothDeviceInfo bdi = new BluetoothDeviceInfo(remoteAddress);
        try
        {
            if (!bdi.Authenticated)
            {
                string pair = rd.Pin; /* PIN for your dongle */
                bool paired = BluetoothSecurity.PairRequest(bdi.DeviceAddress, pair);
            }
        }
        catch (Exception ex)
        {
            //Log and rethrow
        } 
    }
