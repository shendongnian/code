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
               workerThread.IsBackground = true;
               workerThread.Start();
               int waitingCiclesCount = 100;
               int cicleIndex = 0;
               int sleepTimeInMiliseconds = 100;
               Dispatcher dispatcher = null;
               while (cicleIndex < waitingCiclesCount)
               {
                   dispatcher = Dispatcher.FromThread(workerThread);
                   if (dispatcher!=null)
                       break;
                   Thread.Sleep(sleepTimeInMiliseconds);
                   cicleIndex = cicleIndex + 1;
               }
               if (dispatcher==null)
               {
                   workerThread.Abort();
                   return null;
               }
               Console.WriteLine(String.Format("thread with id={0} started", workerThread.ManagedThreadId));
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
            
            TestWorker worker=new TestWorker();
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
