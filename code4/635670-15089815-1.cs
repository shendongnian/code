    public class Server
    {
        public static void Main()
        {
            ThreadStart server1 = new ThreadStart(ServerSide);
            Thread server2 = new Thread(server1);
            ThreadStart client1 = new ThreadStart(ClientSide);
            Thread client2 = new Thread(client1);
            server2.Start();
            client2.Start();
        }
        public static void ServerSide()
        {
            Console.WriteLine("ServerSide....");
            TcpChannel ch2 = (TcpChannel)Helper.GetChannel(2233, true);
            ChannelServices.RegisterChannel(ch2, false);
            IRemoteObject objRemoteRef = (IRemoteObject)Activator.GetObject(
                typeof(IRemoteObject), "tcp://127.0.0.1:2333/M");
            while (true)
            {
                string x = Console.ReadLine();
                objRemoteRef.GetData(x);
            }
        }
        public static void ClientSide()
        {
            Console.WriteLine("ClientSide....");
            TcpChannel ch1 = (TcpChannel)Helper.GetChannel(0, true);
            ChannelServices.RegisterChannel(ch1, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(RemoteObject), "M", WellKnownObjectMode.Singleton);
            Console.ReadLine();
        }
    }
