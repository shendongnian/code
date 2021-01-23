    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            NetworkChange.NetworkAddressChanged += new NetworkAddressChangedEventHandler(NetworkAddressChanged);
        }
        protected override void OnStop()
        {
        }
        private void NetworkAddressChanged(object sender, EventArgs e)
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface n in adapters)
            {
                EventLog.WriteEntry("NetworkMonitor",String.Format("{0} is {1}", n.Name, n.OperationalStatus),EventLogEntryType.Warning);
            }
        }
        
    }
