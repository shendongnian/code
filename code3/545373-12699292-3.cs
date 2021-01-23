    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    namespace SimpleServer
    {
        class Server
        {
            private static TcpListener tcpListener;
            private static int clients;
            static void Main(string[] args)
            {
                tcpListener = new TcpListener(IPAddress.Any, 560);
                tcpListener.Start();
                Console.WriteLine("Server started.");
                while (true)
                {
                    //blocks until a client has connected to the server
                    TcpClient client = tcpListener.AcceptTcpClient();
                    //create a thread to handle communication
                    //with connected client
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                    clientThread.Start(client);
                }
            }
            private static void HandleClientComm(object client)
            {
                int clientCount = Interlocked.Increment(ref clients);
                TcpClient tcpClient = (TcpClient)client;
                NetworkStream clientStream = tcpClient.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();
                Console.WriteLine("Client connected. ({0} connected)", clientCount);
                #region sendingHandler
                byte[] buffer = encoder.GetBytes("Some Contacts as a string!");
                byte[] lengthBuffer = BitConverter.GetBytes(buffer.Length);
                clientStream.Write(lengthBuffer, 0, lengthBuffer.Length);
                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();
                tcpClient.Close();
                #endregion
            }
        }
    }
