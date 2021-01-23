    try
            {
                rcOptions = new ConnectionOptions();
                rcOptions.Authentication = AuthenticationLevel.Packet;
                rcOptions.Impersonation = ImpersonationLevel.Impersonate;
                rcOptions.EnablePrivileges = true;
                rcOptions.Username = servername + @"\" + username;
                rcOptions.Password = password;
                mScope = new ManagementScope(String.Format(@"\\{0}\root\cimv2", servername), rcOptions);
                mScope.Connect();
                if (mScope.IsConnected == true) { MessageBox.Show("Connection Succeeded", "Alert"); } else { MessageBox.Show("Connection Failed", "Alert"); }
                if (mScope.IsConnected == true) { lblConnectionStateWarning.Text = "Connected"; } else { lblConnectionStateWarning.Text = "Disconnected"; } //I have a label that displays connectionstate, you can leave that out
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
