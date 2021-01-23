        public partial class FileMonitor : ServiceBase
        {
            private Timer timer;
            private long interval;
    	    private const string ACCEPTED_FILE_TYPE = "*.csv";
           
            public FileMonitor()
            {           
                this.ServiceName = "Service";
                this.CanStop = true;
                this.CanPauseAndContinue = true;
                this.AutoLog = true;
                this.interval = long.Parse(1000);
            }
    
            public static void Main()
            {
                ServiceBase.Run(new FileMonitor());
            }
            
            protected override void OnStop()
            {
                base.OnStop();
                this.timer.Dispose();
            }
    
            protected override void OnStart(string[] args)
            {
                AutoResetEvent autoEvent = new AutoResetEvent(false);
                this.timer = new Timer(new TimerCallback(ProcessNewFiles), autoEvent, interval, Timeout.Infinite);
            }
    
            private void ProcessNewFiles(Object stateInfo)
            {
                DateTime start = DateTime.Now;
                DateTime complete = DateTime.Now;
                
                try
                {
    				string directoryToMonitor = "c:\mydirectory";
    				DirectoryInfo feedDir = new DirectoryInfo(directoryToMonitor);
    				FileInfo[] feeds = feedDir.GetFiles(ACCEPTED_FILE_TYPE, SearchOption.TopDirectoryOnly);				
    
    				foreach (FileInfo feed in feeds.OrderBy(m => m.LastWriteTime))
    				{
    					// Do whatever you want to do with the file here
    				}
                }
                finally
                {
                    TimeSpan t = complete.Subtract(start);
                    long calculatedInterval = interval - t.Milliseconds < 0 ? 0 : interval - t.Milliseconds;
                    this.timer.Change(calculatedInterval, Timeout.Infinite);
                }
            }       
        }
