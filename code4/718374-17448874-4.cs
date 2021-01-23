    class USBDeviceInfo
    {
        public USBDeviceInfo(string deviceID, string pnpDeviceID, string description)
        {
            this.DeviceID = deviceID;
            this.PnpDeviceID = pnpDeviceID;
            this.Description = description;
        }
        public string DeviceID { get; private set; }
        public string PnpDeviceID { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<string> GetDiskNames()
        {
            using (Device device = Device.Get(PnpDeviceID))
            {
                // get children devices
                foreach (string childDeviceId in device.ChildrenPnpDeviceIds)
                {
                    // get the drive object that correspond to this id (escape the id)
                    foreach (ManagementObject drive in new ManagementObjectSearcher("SELECT DeviceID FROM Win32_DiskDrive WHERE PNPDeviceID='" + childDeviceId.Replace(@"\", @"\\") + "'").Get())
                    {
                        // associate physical disks with partitions
                        foreach (ManagementObject partition in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + drive["DeviceID"] + "'} WHERE AssocClass=Win32_DiskDriveToDiskPartition").Get())
                        {
                            // associate partitions with logical disks (drive letter volumes)
                            foreach (ManagementObject disk in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + partition["DeviceID"] + "'} WHERE AssocClass=Win32_LogicalDiskToPartition").Get())
                            {
                                yield return (string)disk["DeviceID"];
                            }
                        }
                    }
                }
            }
        }
    }
