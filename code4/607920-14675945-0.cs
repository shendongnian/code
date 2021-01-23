    public class RadioButtonTestViewModel : Screen
    {
        private bool newInstallChecked;
        private bool updateInstallChecked;
        private bool serverChecked;
        private bool clientChecked;
    
        public bool NewInstallChecked
        {
            get { return newInstallChecked; }
            set
            {
                if (value.Equals(newInstallChecked)) return;
                newInstallChecked = value;
                NotifyOfPropertyChange(() => NewInstallChecked);
            }
        }
    
        public bool UpdateInstallChecked
        {
            get { return updateInstallChecked; }
            set
            {
                if (value.Equals(updateInstallChecked)) return;
                updateInstallChecked = value;
                NotifyOfPropertyChange(() => UpdateInstallChecked);
            }
        }
    
        public bool ServerChecked
        {
            get { return serverChecked; }
            set
            {
                if (value.Equals(serverChecked)) return;
                serverChecked = value;
                NotifyOfPropertyChange(() => ServerChecked);
            }
        }
    
        public bool ClientChecked
        {
            get { return clientChecked; }
            set
            {
                if (value.Equals(clientChecked)) return;
                clientChecked = value;
                NotifyOfPropertyChange(() => ClientChecked);
            }
        }
    
        public void SaveAndClose()
        {
            Options.Client = ClientChecked;
            Options.NewInstall = NewInstallChecked;
            
            Options.Server = ServerChecked;
            Options.UpdateInstall = UpdateInstallChecked;
    
            TryClose();
        }
    
        protected override void OnInitialize()
        {
            base.OnInitialize();
    
            ClientChecked = Options.Client;
            NewInstallChecked = Options.NewInstall;
    
            ServerChecked = Options.Server;
            UpdateInstallChecked = Options.UpdateInstall;
        }
    
        public static class Options
        {
            public static bool NewInstall { get; set; }
            public static bool UpdateInstall { get; set; }
    
            public static bool Server { get; set; }
            public static bool Client { get; set; }
        }
    }
