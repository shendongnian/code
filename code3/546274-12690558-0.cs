    string sysGuid = "";
            try
            {
                ManagementObjectSearcher ms = new ManagementObjectSearcher("SELECT * FROM Win32_Volume");
                foreach (ManagementObject mo in ms.Get())
                {
                    if (mo["Label"].ToString() == "System Reserved")
                    {
                        sysGuid = mo["DeviceID"].ToString();
                        break;
                    }
                }
            }
            catch (Exception) {}
