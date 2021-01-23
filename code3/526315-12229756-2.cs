    class Program
    {
        static byte[] dataToSend = new byte[] { 1, 2, 3, 4, 5 };
        // get the ip and port number where the client will be listening on
        static IPEndPoint GetClientInfo()
        {
            // wait for client to send data
            using (UdpClient listener = new UdpClient(11000))
            {
                IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, 11000);
                byte[] receive_byte_array = listener.Receive(ref groupEP);
                return groupEP;
            }
        }
        static void Main(string[] args)
        {
            var info = GetClientInfo(); // get client info
            /* NOW THAT WE HAVE THE INFO FROM THE CLIENT WE ARE GONG TO SEND
               DATA TO IT FROM SCRATCH!. NOTE THE CLIENT IS BEHIND A NAT AND
               WE WILL STILL BE ABLE TO SEND PACKAGES TO IT
            */
            
            // create a new client. this client will be created on a 
            // different computer when I do readl udp punch holing
            UdpClient newClient = ConstructUdpClient(info);
            // send data
            newClient.Send(dataToSend, dataToSend.Length);            
        }
        // Construct a socket with the info received from the client
        static UdpClient ConstructUdpClient(IPEndPoint clientInfo)
        {          
            var ip = clientInfo.Address.ToString();
            var port = clientInfo.Port;
            // this is the part I was missing!!!!
            // the local end point must match. this should be the ip this computer is listening on
            // and also the port            
            UdpClient client = new UdpClient(new IPEndPoint( IPAddress.Any, 11000));
            // lastly we are missing to set the end points. (ip and port client is listening on)
            // the connect method sets the remote endpoints
            client.Connect(ip, port);
            return client;
        }
    }
