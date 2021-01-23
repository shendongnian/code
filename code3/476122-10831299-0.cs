    ManualResetEvent exit = new ManualResetEvent(false);
    for (int i = 0; i <= mDevices.Count; i++)
        {
            ThreadStart workerThread = delegate { pollDevices(mDevices[i - 2], this, exit); };
            new Thread(workerThread).Start();
        }
    public void pollDevices(IDeviceInterface device, DeviceManager mainUI, ManualResetEvent exit)
    {
        while(!exit.WaitOne(1000))
        {
             // do work
             device.connect(device, this);
        }
    }
