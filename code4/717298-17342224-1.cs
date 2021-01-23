    class Program {
        static string location = "D:\\ThreadingDemo\\Clients\\";
        static Double timeinterval;
    	
    
        static void Main(string[] args) {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(location);
            foreach (System.IO.DirectoryInfo g in dir.GetDirectories()) {
                var th = new Thread(() => DoWork(g.Name)); //** Passes CLIENT NAME to the method
                th.Name = g.Name;
                th.Start();
                Console.WriteLine(" ThreadStart - ClientName : " + g.Name + " " + DateTime.Now);
            }
            Console.ReadKey();
        }
    
        public static void DoWork(string fname) {
    		var emailTriggerTimer = new System.Timers.Timer();
            emailTriggerTimer.Interval = GetsExecutionTimeFromConfigFile(); //** Gets Client specific FIRST EXECUTION TIME and converts to Time Interval
            emailTriggerTimer.Elapsed += new System.Timers.ElapsedEventHandler((sender, e) => emailTriggerTimer_Elapsed(sender, e, fname, emailTriggerTimer));
            emailTriggerTimer.Enabled = true;
            emailTriggerTimer.AutoReset = true;
            emailTriggerTimer.Start();
    
            Console.WriteLine(" DoWork - ClientName :" + fname + " " + DateTime.Now);
        }
    
        private static void emailTriggerTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e, string fname, System.Timers.Timer emailTriggerTimer) {
            emailTriggerTimer.Stop();
            emailTriggerTimer.Enabled = false;
    
            Console.WriteLine(fname + " Elapsed "   + DateTime.Now);
            emailTriggerTimer.Interval = GetsTimeIntervalFromConfigFile(); //** Gets Client specific TIME INTERVAL
    
            emailTriggerTimer.Start();
            emailTriggerTimer.Enabled = true;
        }
    }
