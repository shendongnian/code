    public static class Crypto
        {
            // Protect the connectionStrings section. 
            #region Public Methods and Operators
    
            public static bool ProtectConfiguration(string path)
            {
                string provider = "X509ProtectedConfigProvider";
    
                // Get the application configuration file.
                Configuration config = ConfigurationManager.OpenExeConfiguration(path);
    
                // Get the section to protect.
                ConfigurationSection connStrings = config.ConnectionStrings;
    
                if (connStrings != null)
                {
                    if (!connStrings.SectionInformation.IsProtected)
                    {
                        if (!connStrings.ElementInformation.IsLocked)
                        {
                            // Protect the section.
                            connStrings.SectionInformation.ProtectSection(provider);
    
                            connStrings.SectionInformation.ForceSave = true;
                            config.Save(ConfigurationSaveMode.Full);
    
                            return true;
                        }
    
                        return false;
                    }
    
                    return true;
                }
    
                return false;
            }
    
            // Unprotect the connectionStrings section. 
            public static void UnProtectConfiguration(string path)
            {
                // Get the application configuration file.
                Configuration config = ConfigurationManager.OpenExeConfiguration(path);
    
                // Get the section to unprotect.
                ConfigurationSection connStrings = config.ConnectionStrings;
    
                if (connStrings != null)
                {
                    if (connStrings.SectionInformation.IsProtected)
                    {
                        if (!connStrings.ElementInformation.IsLocked)
                        {
                            // Unprotect the section.
                            connStrings.SectionInformation.UnprotectSection();
    
                            connStrings.SectionInformation.ForceSave = true;
                            config.Save(ConfigurationSaveMode.Full);
                        }
                    }
                }
            }
    
            #endregion
        }
    }
