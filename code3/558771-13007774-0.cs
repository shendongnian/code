        private JabberClient _client;
        private JabberClient client
        {
            get {
                if (_client == null)
                {
                    _client = new JabberClient();
                    ConfigureClient(_client);
                }
                return _client; 
            }
            set
            {
                _client = value;
                RegisterOnEvents(_client);
            }
        }      
        public MiddleMan()
        {
            jabber.connection.ConferenceManager c = new jabber.connection.ConferenceManager();
            client = new JabberClient();
            ConfigureClient(client);
        }  
        private void ConfigureClient(JabberClient jc)
        {
            JID jid = new JID(LoginInformation.UserName);
            jc.User = jid.User;
            jc.Server = jid.Server;
            if (!String.IsNullOrEmpty(LoginInformation.NetworkHost))
            {
                jc.NetworkHost = LoginInformation.NetworkHost;
            }
            jc.Port = 5222;
            jc.AutoReconnect = 3f;
            jc.AutoLogin = true;
            jc.AutoPresence = true;
            jc.Resource = LoginInformation.Resource;
            jc.Password = LoginInformation.Password;
            jc.KeepAlive = 10;
        }
        private void RegisterOnEvents(JabberClient jc)
        {
            //Messaging
            //jc.OnMessage += new MessageHandler(OnMessageReceived);
            //Login
            jc.OnLoginRequired += (sender) =>
            {
               //code
            };
            jc.OnAuthenticate += (sender) =>
            {
                //code
            };
            jc.OnAuthError += (sender, rp) =>
            {
                //code
                this.Connect();
            };
            //Connection
            jc.OnConnect += (sender, stream) =>
            {
                //code
            };
            jc.OnDisconnect += (sender) =>
            {
                //code
                this.Connect();
            };
            jc.OnError += (sender, ex) =>
            {
                //code
                this.Connect();
            };
            //jc.OnPresence += new PresenceHandler(OnPresence);
        }
