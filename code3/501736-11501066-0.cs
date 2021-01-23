    using System;
    using System.Management;
    using System.Collections;
    
    namespace WmiControl
    {
        public class WMI
        {
            public bool GetDiskSerial(string Computername)
            {
               
                try
                {
                    ManagementScope scope = new ManagementScope(@"\\" + Computername + @"\root\cimv2");
                    scope.Connect();
                    ArrayList hdCollection;
                    ManagementObjectSearcher searcher;
                    if (GetDiskDrive(scope, out hdCollection, out searcher) || GetDiskSerial(scope, hdCollection, ref searcher))
                        return true;
                    else 
                        return false;
                }
                catch (ManagementException)
                {
                    return false;
                }
    
            }
    
            private bool GetDiskSerial(ManagementScope scope, ArrayList hdCollection, ref ManagementObjectSearcher searcher)
            {
                try
                {
    
    
                    ObjectQuery query1 = new ObjectQuery("SELECT * FROM Win32_PhysicalMedia");
    
                    searcher = new ManagementObjectSearcher(scope, query1);
                    int i = 0;
                    string sDiskSerial = "";
                    foreach (ManagementObject wmi_HD in searcher.Get())
                    {
                        // get the hard drive from collection
                        // using index
                        if (i < hdCollection.Count)
                        {
                            HardDrive hd = (HardDrive)hdCollection[i];
                            if (wmi_HD["SerialNumber"] == null)
                                hd.SerialNo = "";
                            else
                                hd.SerialNo = wmi_HD["SerialNumber"].ToString();
                        }
                        ++i;
                    }
                    foreach (HardDrive hd in hdCollection)
                    {
                        if (!String.IsNullOrEmpty(hd.SerialNo))
                        {
                            sDiskSerial = hd.SerialNo;
                            break;
                        }
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
    
            private bool GetDiskDrive(ManagementScope scope, out ArrayList hdCollection, out ManagementObjectSearcher searcher)
            {
                try
                {
                    ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_DiskDrive");
                    hdCollection = new ArrayList();
                    searcher = new ManagementObjectSearcher(scope, query);
                    foreach (ManagementObject wmi_HD in searcher.Get())
                    {
                        HardDrive hd = new HardDrive();
                        hd.Model = wmi_HD["Model"].ToString();
                        hd.Type = wmi_HD["InterfaceType"].ToString();
                        hdCollection.Add(hd);
                        return true;
                    }
                    return true;
                }
                catch (Exception)
                {
                    hdCollection = null;
                    searcher = null;
                    return false;
                }
            }
        }
        class HardDrive
        {
            private string model = null;
            private string type = null;
            private string serialNo = null;
            public string Model
            {
                get { return model; }
                set { model = value; }
            }
            public string Type
            {
                get { return type; }
                set { type = value; }
            }
            public string SerialNo
            {
                get { return serialNo; }
                set { serialNo = value; }
            }
        }
    }
