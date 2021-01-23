        class Transmitter
    {
        public Boolean Transmit(String ip ,String port, String data){
            TcpClient client = new TcpClient();
            int _port = 0;
            int.TryParse(port, out _port);
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(ip), _port);
            client.Connect(serverEndPoint);
            NetworkStream clientStream = client.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes(data);
            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
            return true;
        }
    }
    class Listener
    {
        private TcpListener tcpListener;
        private Thread listenThread;
        // Set the TcpListener on port 13000.
        Int32 port = 8081;
        IPAddress localAddr = IPAddress.Parse("192.168.1.3");
        Byte[] bytes = new Byte[256];
        MainWindow mainwind = null;
        public void Server(MainWindow wind)
        {
            mainwind = wind;
            this.tcpListener = new TcpListener(IPAddress.Any, port);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
            
        }
        private void ListenForClients()
        {
            
            this.tcpListener.Start();
            while (true)
            {
                //blocks until a client has connected to the server
                TcpClient client = this.tcpListener.AcceptTcpClient();
                //create a thread to handle communication 
                //with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }
        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            byte[] message = new byte[4096];
            int bytesRead;
            while (true)
            {
                bytesRead = 0;
                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //a socket error has occured
                   // System.Windows.MessageBox.Show("socket");
                    break;
                }
                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                   // System.Windows.MessageBox.Show("disc");
                    break;
                }
                //message has successfully been received
                ASCIIEncoding encoder = new ASCIIEncoding();
                mainwind.setText(encoder.GetString(message, 0, bytesRead));
                //System.Windows.MessageBox.Show(encoder.GetString(message, 0, bytesRead));
               // System.Diagnostics.Debug.WriteLine(encoder.GetString(message, 0, bytesRead));
            }
            
            tcpClient.Close();
        }
    }
