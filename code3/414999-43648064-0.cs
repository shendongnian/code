            using System.Management;
            string description;
            using (ManagementClass mc = new ManagementClass("Win32_OperatingSystem"))
            using (ManagementObjectCollection moc = mc.GetInstances())
            {
                foreach (ManagementObject mo in moc)
                {
                    if (mo.Properties["Description"] != null)
                    {
                        description = mo.Properties["Description"].Value.ToString();
                        break;
                    }
                }
            }
