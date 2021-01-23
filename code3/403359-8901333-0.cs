    using System;
    using System.IO;
    using System.Net.Sockets;
    using System.Threading;
    using ProtoBuf;
    [ProtoContract]
    public class Player
    {
        [ProtoMember(1)] public int flag;
        [ProtoMember(2)] public Int16 id;
        [ProtoMember(3, DataFormat = DataFormat.Group)] public MyVector3 CharPos;
        [ProtoMember(7)] public bool spawned;
    }
    
    public struct MyVector3
    {
        public readonly float X, Y, Z;
        public MyVector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public override string ToString()
        {
            return string.Format("({0},{1},{2})", X, Y, Z);
        }
    }
    
    static class Program
    {
        static ManualResetEvent evt = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            var player = new Player() {CharPos = new MyVector3(1, 2, 3), flag=123, id=456, spawned=true};
            ThreadPool.QueueUserWorkItem(x =>
            {
                Console.WriteLine("client: waiting for server");
                evt.WaitOne();
                Console.WriteLine("client: opening connection");
                using (var client = new TcpClient("localhost", 15000))
                using (var ns = client.GetStream())
                {
                    serialize(ns, player);
                    ns.Flush();
                    Console.WriteLine("client: wrote player");
    
                    Console.WriteLine("client: waiting for response");
                    while (ns.ReadByte() >= 0)
                    {
                        Console.WriteLine("client: receiving...");
                    }
                    Console.WriteLine("client: connection closed by server");
                    ns.Close();
                }
            });
            TcpListener serverSocket = new TcpListener(15000);
            TcpClient clientSocket;
            
            serverSocket.Start();
    
            Console.WriteLine("server: accepting connections");
            evt.Set();
            while (true)
            {
                Console.WriteLine("server: waiting for client...");
                clientSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine("server: got client");
                using (NetworkStream networkStream = clientSocket.GetStream())
                {
                    var fromNetwork = deserialize(networkStream);
                    Console.WriteLine("server: got player");
                    Console.WriteLine("> flag: {0}", fromNetwork.flag);
                    Console.WriteLine("> id: {0}", fromNetwork.id);
                    Console.WriteLine("> spawned: {0}", fromNetwork.spawned);
                    Console.WriteLine("> pos: {0}", fromNetwork.CharPos);
                }
            }
    
        }
        public static void serialize(Stream dest, Player player)
        {
            if (player == null) throw new ArgumentNullException();
            Serializer.SerializeWithLengthPrefix(dest, player, PrefixStyle.Base128);
        }
    
        public static Player deserialize(Stream inc)
        {
            Player obj = Serializer.DeserializeWithLengthPrefix<Player>(inc, PrefixStyle.Base128);
            return obj;
        }
    }
