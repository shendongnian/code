    class Program
    {
        static Socket Klient;
        static IPEndPoint endPoint;
        static void Main(string[] args)
        {
            Klient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string command;
            Console.WriteLine("Write IP address");
            command = Console.ReadLine();
            IPAddress Address;
            while(!IPAddress.TryParse(command, out Address)) 
            {
                Console.WriteLine("wrong IP format");
                command = Console.ReadLine();
            }
            Console.WriteLine("Write port");
            command = Console.ReadLine();
            
            int port;
            while (!int.TryParse(command, out port) && port > 0)
            {
                Console.WriteLine("Wrong port number");
                command = Console.ReadLine();
            }
            endPoint = new IPEndPoint(Address, port); 
            ConnectC(Address, port);
            while(Klient.Connected)
            {
                Console.ReadLine();
                Odesli();
            }
        }
        public static void ConnectC(IPAddress ip, int port)
        {
            IPEndPoint endPoint = new IPEndPoint(ip, port);
            Console.WriteLine("Connecting...");
            try
            {
                Klient.Connect(endPoint);
                Console.WriteLine("Connected!");
            }
            catch
            {
                Console.WriteLine("Connection fail!");
                return; 
            }
            Task t = new Task(WaitForMessages); 
            t.Start(); 
        }
        public static void SendM()
        {
            string message = "Actualy date is " + DateTime.Now; 
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            Console.WriteLine("Sending: " + message);
            Klient.Send(buffer);
        }
        public static void WaitForMessages()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[64]; 
                    Console.WriteLine("Waiting for answer");
                    Klient.Receive(buffer, 0, buffer.Length, 0); 
                    string message = Encoding.UTF8.GetString(buffer); 
                    Console.WriteLine("Answer: " + message); 
                }
            }
            catch
            {
                Console.WriteLine("Disconnected");
            }
        }
    }
}
