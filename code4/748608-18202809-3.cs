    public static void RetrieveUSBDevices(int vid, int pid)
    {
            var usbFinder = new UsbDeviceFinder(vid, pid);
            var usbDevices = new UsbRegDeviceList();
            usbDevices = usbDevices.FindAll(usbFinder);
    }
