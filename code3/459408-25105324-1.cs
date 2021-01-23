    AllowRemoteAssistance = true;
                AllowConnections = true;
                RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
                key = key.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server", true);
                if (AllowRemoteAssistance)
                    key.SetValue("fDenyTSConnections", 0, RegistryValueKind.DWord);
                else
                    key.SetValue("fDenyTSConnections", 1, RegistryValueKind.DWord);
                key.Flush();
                if (key != null)
                    key.Close();
                key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
                key = key.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Remote Assistance", true);
                if (AllowConnections)
                    key.SetValue("fAllowToGetHelp", 1, RegistryValueKind.DWord);
                else
                    key.SetValue("fAllowToGetHelp", 0, RegistryValueKind.DWord);
                key.Flush();
                if (key != null)
                    key.Close();
