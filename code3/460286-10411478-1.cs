    if (Properties.Settings.Default.settingsUpgrade)
            {
                Properties.Settings.Default.Upgrade();
                
                string strVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string installedVersion = Properties.Settings.Default.installedVersion;
                if (!string.IsNullOrEmpty(installedVersion) && installedVersion != strVersion)
                {
                    WhatsNew WhatsNew = new WhatsNew();
                    WhatsNew.Show();
                    WhatsNew.BringToFront();
                }
                Properties.Settings.Default.installedVersion = strVersion;
                Properties.Settings.Default.settingsUpgrade = false;
                Properties.Settings.Default.Save();
            }
