    public static void RetrieveUSBDevices(int vid, int pid)
    {
    	//Find devices matching the vendorId and productId (vid and pid)
    	UsbDeviceFinder USBFinder = new UsbDeviceFinder(vid, pid);
    	
    	//Find all devices with vid and pid
    	var usbDevices = USBRegistryDevices.AllDevices.FindAll(USBFinder);
    }
