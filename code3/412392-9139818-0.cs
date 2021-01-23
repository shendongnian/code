    class MyCacheDependency : CacheDependency
    {
        private const int PoolInterval = 5000;
        private readonly Timer _timer;
        private readonly string _readedContent;
        public static event EventHandler MyEvent;
    
        public MyCacheDependency()
        {
            _timer = new Timer(CheckDependencyCallback, this, PoolInterval, PoolInterval);
            _readedContent = ReadContentFromFile();
            MyEvent += new EventHandler(MyEventHandler);
        }
       protected void MyEventHandler(object sender, EventArgs e) {
        NotifyDependencyChanged(sender, e);
       }
    
        private void CheckDependencyCallback(object sender)
        {
            lock (_timer)
            {
                if (_readedContent != ReadContentFromFile())
                {
                    if(MyEvent!=null)
                        MyEvent(sender, EventArgs.Empty);
                }
            }
        }
    
        private static string ReadContentFromFile()
        {
            return File.ReadAllText(@"C:\file.txt");
        }
    
        protected override void DependencyDispose()
        {
            if (_timer != null) _timer.Dispose();
    
            base.DependencyDispose();
        }
    }
