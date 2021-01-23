                ManagementScope ms = new ManagementScope();
                ObjectQuery oQuery = new ObjectQuery("Select * from Win32_NTLogEvent where Logfile = 'Application' and type ='Error'");
                ManagementObjectSearcher oS = new ManagementObjectSearcher(ms, oQuery);
                ManagementObjectCollection oCollection = oS.Get();
                var i2 = oCollection.Cast<ManagementObject>().First();
                DateTime timewritten = ManagementDateTimeConverter.ToDateTime(i2["TimeWritten"].ToString());
