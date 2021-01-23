    public class ReceivedMessageEventArgs : EventArgs
    {
        public ReceivedMessageEventArgs(string message)
        {
            if (message == null) throw new ArgumentNullException("message");
            Message = message;
        }
        public string Message { get; private set; }
    }
    public class SomeService
    {
        private readonly INetworkClient _networkClient;
        private string _buffer;
        public SomeService(INetworkClient networkClient)
        {
            if (networkClient == null) throw new ArgumentNullException("networkClient");
            _networkClient = networkClient;
            _networkClient.Disconnected += OnDisconnect;
            _networkClient.BufferReceived += OnBufferReceived;
            Connected = true;
        }
        public bool Connected { get; private set; }
        public event EventHandler<ReceivedMessageEventArgs> MessageReceived = delegate { };
        public void Send(string msg)
        {
            if (msg == null) throw new ArgumentNullException("msg");
            if (Connected == false)
                throw new InvalidOperationException("Not connected");
            var buffer = Encoding.ASCII.GetBytes(msg + "\n");
            _networkClient.Send(buffer, 0, buffer.Length);
        }
        private void OnDisconnect(object sender, EventArgs e)
        {
            Connected = false;
            _buffer = "";
        }
        private void OnBufferReceived(object sender, ReceivedEventArgs e)
        {
            _buffer += Encoding.ASCII.GetString(e.Buffer, e.Offset, e.Count);
            var pos = _buffer.IndexOf('\n');
            while (pos > -1)
            {
                var msg = _buffer.Substring(0, pos);
                MessageReceived(this, new ReceivedMessageEventArgs(msg));
                _buffer = _buffer.Remove(0, pos + 1);
                pos = _buffer.IndexOf('\n');
            }
        }
    }
