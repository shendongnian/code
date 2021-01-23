    public partial class ServerClass : Form
    {
        public ServerClass()
        {
            InitializeComponent();
            Class1.MyServer = this;
            TcpChannel channel = new TcpChannel(30000);
            ChannelServices.RegisterChannel(channel, true);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Class1), "CSBU", WellKnownObjectMode.SingleCall);
        }
    }
