    public class P2PPeer
    {
        public string localIp;
        public string externalIp;
        public int localPort;
        public int externalPort;
        public bool isOnLan;
        P2PClient client;
        public delegate void ReceivedBytesFromPeerCallback(byte[] bytes);
        public event ReceivedBytesFromPeerCallback OnReceivedBytesFromPeer;
        public P2PPeer(string localIp, string externalIp, int localPort, int externalPort, P2PClient client, bool isOnLan)
        {
            this.localIp = localIp;
            this.externalIp = externalIp;
            this.localPort = localPort;
            this.externalPort = externalPort;
            this.client = client;
            this.isOnLan = isOnLan;
            if (isOnLan)
            {
                IPEndPoint endPointLocal = new IPEndPoint(IPAddress.Parse(localIp), localPort);
                Thread localListener = new Thread(() => ReceiveMessage(endPointLocal));
                localListener.IsBackground = true;
                localListener.Start();
            }
            else
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(externalIp), externalPort);
                Thread externalListener = new Thread(() => ReceiveMessage(endPoint));
                externalListener.IsBackground = true;
                externalListener.Start();
            }
        }
        public void SendBytes(byte[] data)
        {
            if (client.udpClient == null)
            {
                throw new Exception("P2PClient doesn't have a udpSocket open anymore");
            }
            //if (isOnLan) // This would work but I'm not sure how to test if they are on LAN so I'll just use both for now
            {
                client.udpClient.Send(data, data.Length, new IPEndPoint(IPAddress.Parse(localIp), localPort));
            }
            //else
            {
                client.udpClient.Send(data, data.Length, new IPEndPoint(IPAddress.Parse(externalIp), externalPort));
            }
        }
        // Encoded in UTF8
        public void SendString(string str)
        {
            SendBytes(System.Text.Encoding.UTF8.GetBytes(str));
        }
        void ReceiveMessage(IPEndPoint endPoint)
        {
            while (client.udpClient != null)
            {
                byte[] message = client.udpClient.Receive(ref endPoint);
                if (OnReceivedBytesFromPeer != null)
                {
                    OnReceivedBytesFromPeer(message);
                }
                //string receiveString = Encoding.UTF8.GetString(message);
                //Console.Log("got: " + receiveString);
            }
        }
    }
