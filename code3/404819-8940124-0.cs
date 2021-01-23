    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    namespace ConsoleServer
    {
    class Program
    {
        private static void Worker(Object sockObj)
        {
            var mySocket = (Socket) sockObj;
            using(var netStream = new NetworkStream(mySocket))
            {
                //Handle work;
            }            
        }
        static void Main(string[] args)
        {
            int port = 80;
            // create the socket
            Socket listenSocket = new Socket(AddressFamily.InterNetwork,
                                             SocketType.Stream,
                                             ProtocolType.Tcp);
            // bind the listening socket to the port
            IPAddress hostIP = (Dns.Resolve(IPAddress.Any.ToString())).AddressList[0];
            IPEndPoint ep = new IPEndPoint(hostIP, port);
            listenSocket.Bind(ep);
            // start listening
            listenSocket.Listen(125);
            while (true)
            {
                Socket mySocket = listenSocket.Accept();
                ThreadPool.QueueUserWorkItem(new WaitCallback(Worker), mySocket);
            }
        }
    }
}
