    public partial class Form1 : Form
    {
        private TcpListener _tcpListener;
        private bool _keepRunning;
        private Thread _listenerThread;
        private Socket _clientSocket;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var address = IPAddress.Parse("127.0.0.1");
            _tcpListener = new TcpListener(address, 49152);
            _keepRunning = true;
            _listenerThread = new Thread(Listen);
            _listenerThread.Start();
            button1.Enabled = false;
            button2.Enabled = true;
        }
        private void Listen()
        {
            try
            {
                _tcpListener.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
            _keepRunning = true;
            while (_keepRunning)
            {
                try
                {
                    _clientSocket = _tcpListener.AcceptSocket();
                    var buffer = new byte[8192];
                    var bytesReceived = _clientSocket.Receive(buffer);
                    var checkString = String.Empty;
                    if (_keepRunning)
                    {
                        // bytesReceived can be 0 if the remote socket disconnected
                        if (bytesReceived > 0)
                        {
                            checkString = Encoding.ASCII.GetString(buffer, 0, bytesReceived);
                            // Client is waiting to know operation is complete- so send him some char...
                            var encoder = new ASCIIEncoding();
                            _clientSocket.Send(encoder.GetBytes("v"));
                        }
                        if (_clientSocket.Connected) _clientSocket.Disconnect(true);
                    }
                    _clientSocket.Close();
                }
                catch (Exception ex)
                {
                    // really should do something with these exceptions
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (_tcpListener != null)
            {
                _keepRunning = false;
                if (_tcpListener.Server.Connected)
                {
                    _tcpListener.Server.Disconnect(true);
                }
                _tcpListener.Stop();
                if (_clientSocket != null)
                {
                    _clientSocket.Close();
                    _clientSocket = null;
                }
                _listenerThread.Join();
            }
            button1.Enabled = true;
            button2.Enabled = false;
        }
    }
