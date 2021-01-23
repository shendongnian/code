        public Main()
        {   
            InitializeComponent();
            Messenger.Default.Register<CloseMessage>(this, HandleCloseMessage);
        }
        private void HandleCloseMessage(CloseMessage closeMessage)
        {
            Close();
        }
