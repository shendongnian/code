       private bool _initialized = false;
    
        public MyMsgBus() {}
       
        public Initialize(string busname) // Make this part of interface    
        {
           myMsgBus = new List<string>();
    
           myIpc = CreateIpcChannel(busname);
           ChannelServices.RegisterChannel(myIpc);
    
           var entry = new WellKnownServiceTypeEntry(
              typeof(MxServeBus),
              "MyRemoteObj.rem",
              WellKnownObjectMode.Singleton);
    
           RemotingConfiguration.RegisterWellKnownServiceType(entry);
           _initialized = true;
        }
