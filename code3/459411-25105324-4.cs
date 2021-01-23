                AllowRemoteAssistance = true;
                RemoteDesktopSelectNumber = 2;
                RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
                key = key.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Remote Assistance", true);
                if (AllowRemoteAssistance)
                    key.SetValue("fAllowToGetHelp", 1, RegistryValueKind.DWord);
                else
                    key.SetValue("fAllowToGetHelp", 0, RegistryValueKind.DWord);
                key.Flush();
                if (key != null)
                    key.Close();
                if (RemoteDesktopSelectNumber == 1 || RemoteDesktopSelectNumber == 2)
                {
                    key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
                    key = key.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server\WinStations\RDP-Tcp\", true);
                    key.SetValue("UserAuthentication", 0, RegistryValueKind.DWord);
                    key.Flush();
                    if (key != null)
                        key.Close();
                    key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
                    key = key.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server", true);
                    if (RemoteDesktopSelectNumber == 1)
                        key.SetValue("fDenyTSConnections", 1, RegistryValueKind.DWord);
                    else
                        key.SetValue("fDenyTSConnections", 0, RegistryValueKind.DWord);
                    key.Flush();
                    if (key != null)
                        key.Close();
                }
                else if (RemoteDesktopSelectNumber == 3)
                {
                    key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
                    key = key.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server\WinStations\RDP-Tcp\", true);
                    key.SetValue("UserAuthentication", 1, RegistryValueKind.DWord);
                    key.Flush();
                    if (key != null)
                        key.Close();
                }
