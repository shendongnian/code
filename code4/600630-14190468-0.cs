        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
            string targetDirectory = Context.Parameters["targetdir"];
            string ServerName = Context.Parameters["ServerName"];
            System.Diagnostics.Debugger.Break();
            string exePath = string.Format("{0myapp.exe", targetDirectory);
 
            Configuration config = ConfigurationManager.OpenExeConfiguration(exePath);
            config.AppSettings.Settings["ServerName"].Value = ServerName;
            
            //Get ServiceModelSectionGroup from config
            ServiceModelSectionGroup group = ServiceModelSectionGroup.GetSectionGroup(config);
            //get the client section
            ClientSection clientSection = group.Client;
            //get the first endpoint
            ChannelEndpointElement channelEndpointElement = clientSection.Endpoints[0];
            //get the address attribute and replace servername in the string.
            string address = channelEndpointElement.Address.ToString().ToLower().Replace("ServerName", ServerName);
            //set the Address attribute to the new value
            channelEndpointElement.Address = new Uri(address);
            config.Save();
            }
        }
