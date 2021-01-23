        private static string RegistryInstallDate()
        {
            DateTime InstallDate = new DateTime(1970, 1, 1, 0, 0, 0);  //NOT a unix timestamp 99% of online solutions incorrect identify this as!!!! 
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Registry");
            
            foreach (ManagementObject wmi_Windows in searcher.Get())
            {
                try
                {
                    ///CultureInfo ci = CultureInfo.InvariantCulture;
                    string installdate = wmi_Windows["InstallDate"].ToString(); 
                    //InstallDate is in the UTC format (yyyymmddHHMMSS.xxxxxx±UUU) where critically
                    // 
                    // xxxxxx is milliseconds and       
                    // ±UUU   is number of minutes different from Greenwich Mean Time. 
                    if (installdate.Length==25)
                    {
                        string yyyymmddHHMMSS = installdate.Split('.')[0];
                        string xxxxxxsUUU = installdate.Split('.')[1];      //±=s for sign
                        int year  = int.Parse(yyyymmddHHMMSS.Substring(0, 4));
                        int month = int.Parse(yyyymmddHHMMSS.Substring(4, 2));
                        int date  = int.Parse(yyyymmddHHMMSS.Substring(4 + 2, 2));
                        int hour  = int.Parse(yyyymmddHHMMSS.Substring(4 + 2 + 2, 2));
                        int mins  = int.Parse(yyyymmddHHMMSS.Substring(4 + 2 + 2 + 2,  2));
                        int secs  = int.Parse(yyyymmddHHMMSS.Substring(4 + 2 + 2 + 2 + 2, 2));
                        int msecs = int.Parse(xxxxxxsUUU.Substring(0, 6));
                        double UTCoffsetinMins = double.Parse(xxxxxxsUUU.Substring(6, 4));
                        TimeSpan UTCoffset = TimeSpan.FromMinutes(UTCoffsetinMins);
                        InstallDate = new DateTime(year, month, date, hour, mins, secs, msecs) + UTCoffset; 
                    }
                    break;
                }
                catch (Exception)
                {
                    InstallDate = DateTime.Now; 
                }
            }
            return String.Format("{0:ddd d-MMM-yyyy h:mm:ss tt}", InstallDate);      
        }
