        private static string GetVideoControllerDescription()
        {
            Console.WriteLine("GetVideoControllerDescription");
            var s1 = new ManagementObjectSearcher("select * from Win32_VideoController");
            foreach (ManagementObject oReturn in s1.Get())
            {
                var desc = oReturn["AdapterRam"];
                if ( desc == null) continue;
                return oReturn["Description"].ToString().Trim();
            }
            return string.Empty;
        }
