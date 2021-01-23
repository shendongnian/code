    private static string GetType(string fileName)
        {
            string type = "Unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("") != null)
            {
                string lookup = regKey.GetValue("").ToString();
                if (!string.IsNullOrEmpty(lookup))
                {
                    var lookupKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(lookup);
                    if (lookupKey != null)
                    {
                        type = lookupKey.GetValue("").ToString();
                    }
                }
            }
            return type;
        }
