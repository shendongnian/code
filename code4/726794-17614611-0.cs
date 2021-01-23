        InitWindow I = null;
        Thread C = null;  
        
        public InitWindow()
        {
            InitializeComponent();
            I = this;
            C = Thread.CurrentThread;  
            Thread T = new Thread(() =>
            {
                MainWindow M = new MainWindow();
                M.Show();
                M.ContentRendered += M_ContentRendered;
                System.Windows.Threading.Dispatcher.Run();
                M.Closed += (s, e) => M.Dispatcher.InvokeShutdown();
            }) { IsBackground = true, Priority = ThreadPriority.Lowest };
            T.SetApartmentState(ApartmentState.STA);
            T.Start();
        }
        void M_ContentRendered(object sender, EventArgs e)
        {
            // Making the parent thread background
            C.IsBackground = true; 
            // foreground the current thread
            Thread.CurrentThread.IsBackground = false;
            // Abort the parent thread
            C.Abort();
        }
