     RegistryKey rKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
                List<string> insApplication = new List<string>();
                if (rKey != null && rKey.SubKeyCount > 0)
                {
                    insApplication = rKey.GetSubKeyNames().ToList();
                }
                int i = 0;
                string version = "";
                foreach (string appName in insApplication)
                {
                    RegistryKey finalKey = rKey.OpenSubKey(insApplication[i]);
                    string installedApp = finalKey.GetValue("DisplayName").ToString();
                    if (installedApp == "Google Chrome")
                    {
                        version = finalKey.GetValue("DisplayVersion").ToString();
                        return;
                    }
                    i++;
                }
