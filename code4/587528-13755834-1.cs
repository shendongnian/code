        static void OnThreadStart()
        {
           Dispatcher.Run();
        }
        private Dispatcher GetNewThreadDispatcher()
        {
            Thread workerThread=null;
            try
            {
               workerThread = new Thread(OnThreadStart);
               workerThread.Start();
                int count = 0;
                while ((workerThread.ThreadState!=ThreadState.Running)||(count<5))
                {
                    Thread.Sleep(100);
                    count = count + 1;
                }
                if (workerThread.ThreadState!=ThreadState.Running)
                {
                    workerThread.Abort();
                    return null;
                }
                Console.WriteLine(String.Format("thread with id={0} started", workerThread.ManagedThreadId));
               Dispatcher dispatcher = Dispatcher.FromThread(workerThread);
               return dispatcher;
            }
            catch (Exception)
            {
                if (workerThread!=null)
                    workerThread.Abort();
                return null;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            
            Worker worker=new Worker();
            Dispatcher dispatcher1 = GetNewThreadDispatcher();
            if(dispatcher1!=null)
                dispatcher1.BeginInvoke(new TestDelegate(worker.DoWork1), DispatcherPriority.Normal);
            else
            {
                MessageBox.Show("Cant create dispatcher1");
            }
            Dispatcher dispatcher2 = GetNewThreadDispatcher();
            if (dispatcher2!=null)
                dispatcher2.BeginInvoke(new TestDelegate(worker.DoWork2), DispatcherPriority.Normal);
            else
            {
                MessageBox.Show("Cant create dispatcher2");
            }
        }   
