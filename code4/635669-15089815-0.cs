    public class Client
    {
        public static void Main(string[] args)
        {
            ThreadStart client1 = new ThreadStart(ClientSide);
            Thread client2 = new Thread(client1);
            ThreadStart server1 = new ThreadStart(ServerSide);
            Thread server2 = new Thread(server1);
            client2.Start();
            server2.Start();
        }
        public static void ClientSide()
        {
            Console.WriteLine("ClientSide....");
            TcpChannel ch2 = (TcpChannel)Helper.GetChannel(2333, true);
            ChannelServices.RegisterChannel(ch2, false);
            IRemoteObject objRemoteRef = (IRemoteObject)Activator.GetObject(
                typeof(IRemoteObject), "tcp://127.0.0.1:2233/M");
            while (true)
            {
                string x = Console.ReadLine();
                objRemoteRef.GetData(x);
            }
        }
        public static void ServerSide()
        {
            Console.WriteLine("ServerSide....");
            TcpChannel ch2 = (TcpChannel)Helper.GetChannel(0, true);
            ChannelServices.RegisterChannel(ch2, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(RemoteObject), "M", WellKnownObjectMode.Singleton);
        }
    }
