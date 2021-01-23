    namespace ConsoleApplication1
    {
    using System;
    using System.Collections.Generic;
    using System.Management; // need to add System.Management to your project references.
    class Program
    {
        static void Main(string[] args)
        {
            var usbDevices = GetUSBDevices();
            foreach (var usbDevice in usbDevices)
            {
                Console.WriteLine("Device ID: {0}", usbDevice.DeviceID);
            }
            Console.Read();
        }
        static List<USBDeviceInfo> GetUSBDevices()
        {
            List<USBDeviceInfo> devices = new List<USBDeviceInfo>();
            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
                collection = searcher.Get();
            foreach (var device in collection)
            {
                devices.Add(new USBDeviceInfo(
                (string)device.GetPropertyValue("DeviceID")
                ));
            }
            collection.Dispose();
            return devices;
        }
    }
    class USBDeviceInfo
    {
        public USBDeviceInfo(string deviceID)
        {
            this.DeviceID = deviceID;
        }
        public string DeviceID { get; private set; }
    }
