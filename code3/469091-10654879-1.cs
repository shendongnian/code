     private Thread _thread;
        public MainWindow()
        {
            InitializeComponent();
            _thread = new Thread(DoWork);
            _thread.Start();
        }
        private void DoWork()
        {
            while (true)
            {
                var str = (string)Dispatcher.Invoke(new Func<object>(() => NotifyLabel.Content));
                str += "a";
                Dispatcher.Invoke(new Action(() => NotifyLabel.Content = str));
                Thread.Sleep(500);
            }
        }
