            try
            {
                RegistryKey myKey = Registry.CurrentUser.OpenSubKey("ControlPanel\\SIP", true);
                if (myKey != null)
                {
                    myKey.SetValue("TurnOffAutoDeploy", 1, RegistryValueKind.DWord);
                    myKey.Close();
                }
            }
            catch { }
