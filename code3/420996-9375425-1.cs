    public object GetRegistryValue(string KeyName, object DefaultValue)
            {
                object res = null;
                try
                {
                    Microsoft.VisualBasic.Devices.Computer c = new Microsoft.VisualBasic.Devices.Computer();
                    Microsoft.Win32.RegistryKey k = c.Registry.CurrentUser.OpenSubKey("Software\\YourAppName", true);
                    if (k != null)
                    {
                        res = k.GetValue(KeyName, DefaultValue);
                    }
                    else
                    {
                        k = c.Registry.CurrentUser.CreateSubKey("Software\\YourAppName");
                    }
                    if (k != null)
                        k.Close();
                    // ex As Exception
                }
                catch
                {
                    //PromptMsg(ex)
                }
                return res;
            }
    
    public void SetRegistryValue(string KeyName, object _Value)
            {
                try
                {
                    Microsoft.VisualBasic.Devices.Computer c = new Microsoft.VisualBasic.Devices.Computer();
    
                    Microsoft.Win32.RegistryKey k = c.Registry.CurrentUser.OpenSubKey("Software\\YourAppName", true);
                    if (k != null)
                    {
                        k.SetValue(KeyName, _Value);
                    }
                    else
                    {
                        k = c.Registry.CurrentUser.CreateSubKey("Software\\YourAppName");
                        k.SetValue(KeyName, _Value);
                    }
                    if (k != null)
                        k.Close();
                    // ex As Exception
                }
                catch
                {
                    //PromptMsg(ex)
                }
            }
