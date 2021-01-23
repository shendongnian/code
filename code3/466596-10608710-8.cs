    public partial class ScreenImage: Form
    {
        ScreenShotClient client;
        public ScreenImage(string baseAddress)
        {
            InitializeComponent();
            NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
            binding.TransferMode = TransferMode.StreamedResponse;
            binding.MaxReceivedMessageSize = 1024 * 1024 * 2;
            client = new ScreenShotClient(binding, new EndpointAddress(baseAddress));
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            picBox.Image = Image.FromStream(client.GetStream());
        }
    }
