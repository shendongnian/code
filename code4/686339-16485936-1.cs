    /// <summary>
    /// Connects to a remote device.
    /// </summary>
    /// <param name="rd">Remote device that the adapter is supposed to connect to.</param>
    public void DoConnection(IRemoteBTDevice rd)
    {
        BluetoothAddress remoteAddress = new BluetoothAddress(Convert.ToInt64(rd.Id, 16));
        BluetoothDeviceInfo bdi = new BluetoothDeviceInfo(remoteAddress);
        bool paired = false;
        try
        {
            if (!bdi.Authenticated)
            {
                string pair = rd.Pin;
                paired = BluetoothSecurity.PairRequest(bdi.DeviceAddress, pair);
                if (!paired)
                {
                    return;
                }
            }
            
            ...
        }
        catch (Exception ex)
        {
            //Log error
        } 
    }
