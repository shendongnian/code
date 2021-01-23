    public UsbDevice MyUsbDevice;
    //Find your vendor id etc by listing all available USB devices
    public UsbDeviceFinder MyUsbFinder = new UsbDeviceFinder(0x2341, 0x0001);
    public IDeviceNotifier UsbDeviceNotifier = DeviceNotifier.OpenDeviceNotifier();
    private void OnDeviceNotifyEvent(object sender, DeviceNotifyEventArgs e)
    {
        if (e.Object.ToString().Split('\n')[1].Contains("0x2341"))
        {
            if (e.EventType == EventType.DeviceArrival)
            {
                Connect();
            }
            else if(e.EventType == EventType.DeviceRemoveComplete)
            {
                ResetConnection();
            }
        }
    }
