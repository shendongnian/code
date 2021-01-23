    private static void Method()
    {
    var list = GetMyUSBDevices();
    //Iterate list here and use Description to find exact device
    }
    private static List<UsbDevice> GetMyUSBDevices()
    {
        var vid = 32903;
        var pid = 36;
        ManagementObjectCollection collection;
        using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
            collection = searcher.Get();
        var usbDevice = 
            (from ManagementBaseObject device in collection 
            select new UsbDevice(
            (string) device.GetPropertyValue("DeviceID"), 
            (string) device.GetPropertyValue("Description"))).ToList();
        var devices = new List<UsbDevice>();
        foreach (var device in collection)
        {
            devices.Add(new UsbDevice(
            (string)device.GetPropertyValue("DeviceID"),
            (string)device.GetPropertyValue("Description")
            ));
        }
        collection.Dispose();
        return (from d in devices where d.DeviceId.Contains("VID_") && d.DeviceId.Contains("PID_") && d.PID.Equals(pid) && d.VID.Equals(vid) select d).ToList();
    }
    public class UsbDevice
    {
        public UsbDevice(string deviceId, string description)
        {
            DeviceId = deviceId;
            Description = description;
        }
    
        public string DeviceId { get; private set; }
        public string Description { get; private set; }
    
        public int VID 
        {
            get { return int.Parse(GetIdentifierPart("VID_"), System.Globalization.NumberStyles.HexNumber); }
        }
    
        public int PID
        {
            get { return int.Parse(GetIdentifierPart("PID_"), System.Globalization.NumberStyles.HexNumber); }
        }
    
        private string GetIdentifierPart(string identifier)
        {
            var vidIndex = DeviceId.IndexOf(identifier, StringComparison.Ordinal);
            var startingAtVid = DeviceId.Substring(vidIndex + 4);
            return startingAtVid.Substring(0, 4);
        }
    }
