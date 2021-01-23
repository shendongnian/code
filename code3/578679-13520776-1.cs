    internal class Program
    {
        private static EventWaitHandle _signalFromClient;
        private static readonly string NameThatClientKnows = Guid.NewGuid().ToString();
        private static readonly CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();
        private const int PingSendTimeout = 30000;
        private static Socket _connectedClientSocket;
        private static Socket _tcpServer;
        private static void Main(string[] args)
        {
            _signalFromClient = new EventWaitHandle(false, EventResetMode.AutoReset, NameThatClientKnows);
            _tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _tcpServer.Bind(new IPEndPoint(IPAddress.Loopback, 0));
            _tcpServer.Listen(1);
            var asyncOpInfo = new SocketAsyncEventArgs();
            asyncOpInfo.Completed += CompletedConnectRequest;
            _tcpServer.AcceptAsync(asyncOpInfo);
            Console.WriteLine("Console stays open, connecting client will say something.");
            Console.ReadLine();
        }
        private static void CompletedConnectRequest(object sender, SocketAsyncEventArgs e)
        {
            Console.WriteLine("Client connected");
            _connectedClientSocket = e.AcceptSocket;
            Task.Factory.StartNew(SendSimpleMessage, CancellationTokenSource.Token);
        }
        private static void SendSimpleMessage()
        {
            while (!CancellationTokenSource.Token.IsCancellationRequested && _connectedClientSocket.Connected)
            {
                try
                {
                    _connectedClientSocket.Send(Encoding.UTF8.GetBytes("PING"));
                    _signalFromClient.WaitOne(PingSendTimeout);
                }
                catch (SocketException) { Dispose(); }
            }
        }
        private static void Dispose()
        {
            CancellationTokenSource.Cancel();
            _connectedClientSocket.Close();
            _tcpServer.Close();
        }
    }
