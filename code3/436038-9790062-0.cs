     string FindPathByInstalledAppEXEName(string appEXEName)
            {
                string path = string.Empty;
    
                try
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Installer\Assemblies");
    
                    string regfilepath = string.Empty;
                    if (key != null)  // Make sure there are Assemblies
                    {
                        foreach (string Keyname in key.GetSubKeyNames())
                        {
                            if (Keyname.IndexOf(appEXEName) > 0)
                            {
                                regfilepath = Keyname;
                                break;
                            }
                        }
                    }
    
                    if (!string.IsNullOrEmpty(regfilepath))
                    {
                        string fullpath = "";
                        for (int a = 0; a < regfilepath.Length; a++)
                        {
                            if (regfilepath.IndexOf("|", a, 1) > 0)
                                fullpath += "\\";
                            else
                                fullpath += regfilepath.Substring(a, 1);
                        }
    
                        path = fullpath.Substring(0, fullpath.LastIndexOf("\\") + 1);
                    }
                }
                catch // (Exception ex)
                {
                }
    
                return path;
            }
