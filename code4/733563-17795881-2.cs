    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConnectUDP();
        }
        private void ConnectUDP()
        {
            UdpClient subscriber = new UdpClient(8899);
            IPAddress addr = IPAddress.Parse("230.0.0.1");
            subscriber.JoinMulticastGroup(addr);
            IPEndPoint ep = null;
            for (int i = 0; i < 10; i++)
            {
                byte[] pdata = subscriber.Receive(ref ep);
                string price = Encoding.ASCII.GetString(pdata);
                //Write data to the label
                label1.Text += price;
            }
            subscriber.DropMulticastGroup(addr);
        }
    }
