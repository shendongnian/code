                string[] m_szModem;
                Microsoft.Win32.RegistryKey m_RegEntry = Microsoft.Win32.Registry.LocalMachine;
                m_RegEntry = m_RegEntry.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Class\{4D36E96D-E325-11CE-BFC1-08002BE10318}");
                //string 
                int i = 0;
                string[] m_szModemEntries = m_RegEntry.GetSubKeyNames();
                m_szModem = new string[m_szModemEntries.Length];
                string m_szModemPort = null;
                string m_szModemName = null;
                foreach (string m_szModemEntry in m_szModemEntries)
                {
                    if (!IsNumber(m_szModemEntry))
                    {
                    }
                    else
                    {
                        m_RegEntry.Close();
                        m_RegEntry = Microsoft.Win32.Registry.LocalMachine;
                        string m_szKeyName = @"SYSTEM\CurrentControlSet\Control\Class\{4D36E96D-E325-11CE-BFC1-08002BE10318}\" + m_szModemEntry;
                        m_RegEntry = m_RegEntry.OpenSubKey(m_szKeyName);
                        m_szModemPort = m_RegEntry.GetValue("AttachedTo").ToString();
                        m_szModemName = m_RegEntry.GetValue("Model").ToString();
                        if (m_szModemName.Contains("<device name>"))
                        {
                            CommPort = m_szModemPort;
                            lbldevicename.Text = "Device connected!";
                            lbldevicename.ForeColor = Color.Green;
                            cmdProgram.Enabled = true;
                            DeviceConnected = true;
                            break;
                        }
                        CommPort = "";
                        cmdProgram.Enabled = false;
                        lbldevicename.Text = "Device not connected!";
                        lbldevicename.ForeColor = Color.Red;
                        DeviceConnected = false;
                    }
                }
