        private string GetUserName()
        {
            string result = "";
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT UserName, Name FROM Win32_ComputerSystem"))
            {
                foreach (ManagementObject mo in searcher.Get())
                {
                    if (mo["UserName"] != null)
                        result = mo["UserName"].ToString();
                    if (mo["Name"] != null)
                        result += " (" + mo["Name"].ToString() + ")";
                }
            }
            return result;
        }
