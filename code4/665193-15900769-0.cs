                //Check
                if (ConfigurationManager.AppSettings.AllKeys.Contains(str someKey))
                {
                    if (configFile.AppSettings.Settings[str someKey].Value == string.Empty)
                        return true;
                }
                else
                {
                    // If app config does not contain needed Keys
                    //Handle issue
                }
