    {
        static string location = "D:\\ThreadingDemo\\Clients\\";
        static Double timeinterval;
        public static System.Timers.Timer emailTriggerTimer;
        static void Main(string[] args)
        {
           
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(location);
            Thread th;
            foreach (System.IO.DirectoryInfo g in dir.GetDirectories())
            {
                th = new Thread(() => DoWork(g.Name));
                th.Name = g.Name;
                th.Start();
                Console.WriteLine(" ThreadStart - ClientName :" + g.Name + " " + DateTime.Now);
            }
            Console.ReadKey();
        }
        public static void DoWork(string fname)
        {
           
            Thread.Sleep(Convert.ToInt32(GetsExecutionTimeFromConfigFile()));//** Gets Client specific FIRST EXECUTION TIME and converts to Time Interval           
            emailTriggerTimer  = new System.Timers.Timer();
            emailTriggerTimer.AutoReset = true;
            emailTriggerTimer.Elapsed += new System.Timers.ElapsedEventHandler((sender, e) => emailTriggerTimer_Elapsed(sender, e, fname));
            emailTriggerTimer.Interval =  GetsTimeIntervalFromConfigFile(); //** Gets Client specific TIME INTERVAL
            emailTriggerTimer.Enabled = true;
           
            emailTriggerTimer.Start();
            Console.WriteLine(" DoWork - ClientName :" + fname + " " + DateTime.Now);
        }
        private static void emailTriggerTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e, string fname)
        {
            
            Console.WriteLine("ClientName : " + fname + " Elapsed " + " " + DateTime.Now );
        }
       
    }
