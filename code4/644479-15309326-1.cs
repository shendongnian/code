        // Window Constructor
        public MainWindow()
        {
            InitializeComponent();
            // Set the event handler.
            base.AddHandler(LogServices.LogEvent, new RoutedLogEventHandler(HandleMsgLog));
        }
        // This is the actual handler.
        public void HandleMsgLog(Object sender, RoutedEventArgs e)
        {
            // Put the received message into the ListBox
            LB.Items.Add((e as LogEventArgs).Msg);
        }
