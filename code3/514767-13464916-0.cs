            var connOptions = new ConnectionOptions();
            connOptions.Authentication = AuthenticationLevel.PacketPrivacy;
            // if you want to connect as someone other than logged in user
            //connOptions.Username = username;
            //connOptions.Password = password;
            var scope = new ManagementScope("\\localhost\WebAdministration", connOptions);
            WqlObjectQuery query = new WqlObjectQuery(`enter code here`string.Format("SELECT * FROM Site WHERE Name = '{0}'", "Default Web Site"));
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
            {
                foreach (ManagementObject site in searcher.Get())
                {
                    ManagementBaseObject inParams = site.GetMethodParameters("Stop");
                    site.InvokeMethod("Stop", inParams, null);
                    ManagementBaseObject inParams2 = site.GetMethodParameters("Start");
                    site.InvokeMethod("Start", inParams2, null);
                }
            }
