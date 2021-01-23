    public static string IsLicenced(bool Licensed = false)
        {
            try
            {                
                foreach (ManagementObject Obj in new ManagementObjectSearcher("root\\CIMV2", "SELECT LicenseStatus FROM SoftwareLicensingProduct WHERE LicenseStatus = 1").Get())
                {
                    Licensed = true;
                }
            }
            catch (ManagementException) { Licensed = false; }
            return Convert.ToString(Licensed);
        }
