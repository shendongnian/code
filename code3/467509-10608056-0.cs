    class Program
    {
        public static int t = 2;
        static System.Timers.Timer aTimer = new System.Timers.Timer();
    
        public static void Main()
        {
    
            // Hook up the Elapsed event for the timer.
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    
            aTimer.Interval = 1000;
            aTimer.Enabled = true;
    
            Console.ReadLine();
        }
        public static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Time remianing..{0}", t);
            t--;
    
            if (t == 0)
            {
                Console.WriteLine("\a");
                Console.WriteLine("Time to check their vitals, again!");
                Console.WriteLine("Press any key to exit...");
                aTimer.Stop();
                Console.ReadLine();
            }
        }
    }
