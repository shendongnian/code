    static class Program
    {
        private static MainForm _mainForm;
        private static MessagingClient _client;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureChat();
            _mainForm = new MainForm();
            Application.Run(_mainForm);
        }
        private static void ConfigureChat()
        {
            _client = new MessagingClient(new BasicMessageFactory());
            _client.Connect(new IPEndPoint(IPAddress.Loopback, 7652));
            _client.Received += OnChatMessage;
        }
        private static void OnChatMessage(object sender, ReceivedMessageEventArgs e)
        {
            _mainForm.InvokeIfRequired(() => _mainForm.AddChatMessage((ChatMessage)e.Message));
        }
        public static void SendChatMessage(ChatMessage msg)
        {
            if (msg == null) throw new ArgumentNullException("msg");
            _client.Send(msg);
        }
    }
