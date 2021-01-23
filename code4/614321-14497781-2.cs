    class TimerClass
        {
            private static System.Timers.Timer aTimer;
        
            public static void Main()
            {
        
                aTimer = new System.Timers.Timer(1000);
        
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        
                aTimer.Interval = 5000;
               
        
                GC.KeepAlive(aTimer);
        
            }
            public static void Start()
            {
               aTimer.Start();
        
        
            }
        
        
        
            private static void OnTimedEvent(object source, ElapsedEventArgs e)
            {
                aTimer.Stop();
                DatabaseUpdation dbUp = new DatabaseUpdation();
                File.AppendAllText(@"C:\Documents and Settings\New Folder\My Documents\demo\abc.txt", "Start" + " " + DateTime.Now.ToString() + Environment.NewLine);
                dbUp.GetDatafromSource();
        
                aTimer.Start();
            }
        
        }
