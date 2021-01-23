    class Server
    {
        private TcpListener tcpListener;
        private Thread listenThread;
        private static string rootPath = "";
        public Server()
        {
            IPAddress ipAddress = Dns.Resolve("localhost").AddressList[0];
            this.tcpListener = new TcpListener(ipAddress, 9501);
            //this.tcpListener = new TcpListener(RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["Endpoint1"].IPEndpoint);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            Trace.WriteLine("Server Working", "Information");
            this.listenThread.Start();
        }
        private void ListenForClients()
        {
            this.tcpListener.Start();
            Trace.WriteLine("Server TcpListener Started", "Information");
            while (true)
            {
                //blocks until a client has connected to the server
                TcpClient client = this.tcpListener.AcceptTcpClient();
                Trace.WriteLine("Server TcpListener New Client", "Information");
                // create a thread to handle the client
                //ParameterizedThreadStart HandleClientConn;
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }
        private void HandleClientComm(object client)
        {
            Trace.WriteLine("Server TcpListener New Client Handle Thread", "Information");
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream nStream = tcpClient.GetStream();
            Image img = Image.FromStream(nStream);
            Trace.WriteLine("Server TcpListener Image is received", "Information");
            string imageName = client.GetHashCode() + ".jpg";
            string imagePath = Path.Combine(Environment.GetEnvironmentVariable("RoleRoot") + @"\", @"approot\"+ imageName);
            img.Save(imagePath, ImageFormat.Jpeg);
            rootPath = Environment.GetEnvironmentVariable("RoleRoot");
            Dictionary<string, string> templates = GetTemplates();
            string sDataDir = String.Format("{0}StasmData\\", rootPath);
            StasmHelper stasm = new StasmHelper();
            Face retVal = stasm.GetHumanFace(imagePath, sDataDir, templates);
            File.Delete(imagePath);
        }
