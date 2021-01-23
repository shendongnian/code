            try
            {
                RegistryKey key = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, TargetMachine.Name);
                key = key.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server", true);
                object val = key.GetValue("fDenyTSConnections");
                bool state = (int)val != 0;
                if (state)
                {
                    key.SetValue("fDenyTSConnections", 0, RegistryValueKind.DWord);
                    MessageBox.Show("Remote Desktop is now ENABLED");
                }
                else
                {
                    key.SetValue("fDenyTSConnections", 1, RegistryValueKind.DWord);
                    MessageBox.Show("Remote Desktop is now DISABLED");
                }
                key.Flush();
                if (key != null)
                    key.Close();
            }
            catch
            {
                MessageBox.Show("Error toggling Remote Desktop permissions");
            }
