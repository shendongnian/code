     static void OnThreadStart()
        {
           Dispatcher.Run();
        }
        private Dispatcher GetNewThreadDispatcher()
        {
           Thread workerThread = new Thread(OnThreadStart);
           workerThread.Start();
           Console.WriteLine(String.Format("thread with id={0} started",workerThread.ManagedThreadId));
           Dispatcher dispatcher = Dispatcher.FromThread(workerThread);
           return dispatcher;
        }
        public MainWindow()
        {
            InitializeComponent();
 
            Dispatcher dispatcher1 = GetNewThreadDispatcher();
            
            Dispatcher dispatcher2 = GetNewThreadDispatcher();
        }
