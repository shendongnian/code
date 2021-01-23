    private static string getAddress()
        {
            RegistryKey rk = Registry.LocalMachine;
            RegistryKey sk = rk.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\explorer\\Shell Folders");
            string address = "";
            if (sk != null)
            {
                address = (string)sk.GetValue("Common Documents", @"c:\Users\Public\Documents");
            }
            return address;
        }
