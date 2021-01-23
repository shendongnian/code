    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        Socketsending socketsending;
        string multicastIP = string.Empty;
        int multicastPort = 0;
        int clientPort = 0;
        string clientSysname = string.Empty;
        string Nodeid = string.Empty;
        string clientIP = string.Empty;
        string recievedText = string.Empty;
        string sendingText = string.Empty;
       
        IPAddress ipAddress;
        IPEndPoint ipEndpoint;
        UdpClient udpClient;
        string[] splitRecievedText;
        byte[] byteRecieve;
        private void Form1_Load(object sender, EventArgs e)
        {
            Random _random = new Random();
            multicastIP = "224.5.6.7";
            multicastPort = 5000;
            Nodeid = "node" + _random.Next(1000, 9999);
            clientPort = _random.Next(1000, 9999);
            clientSysname = Dns.GetHostName();
            ipAddress = Dns.GetHostEntry(clientSysname).AddressList.FirstOrDefault
                (addr => addr.AddressFamily.Equals(AddressFamily.InterNetwork));
            ipEndpoint = new IPEndPoint(ipAddress, clientPort);
            clientIP = ipAddress.ToString();
            label1.Text = "Node id: "+Nodeid;
            label2.Text = "Host Name: " + clientSysname;
            Thread threadMain = new Thread(connect);
            threadMain.Start();
            threadMain = new Thread(receive);
            threadMain.Start();
        }
        void connect()
        {
            socketsending = new Socketsending();
            sendingText = "connect@" + clientSysname + "#" + clientIP + "#" + clientPort + "#" + Nodeid + "#";
            socketsending.send(multicastIP, multicastPort, sendingText);
        }
        void receive()
        {
            udpClient = new UdpClient(clientPort);
            while (true)
            {
                IPEndPoint _ipendpoint = null;
                byteRecieve = udpClient.Receive(ref _ipendpoint);
                recievedText = Encoding.ASCII.GetString(byteRecieve);
                splitRecievedText = recievedText.Split('@');
                if (splitRecievedText[0] == "stop")
                {
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            sendingText= "message@"+Nodeid+'$'+textBox1.Text+'$';
            socketsending.send(multicastIP, multicastPort, sendingText);
            
        }
    }
