    public class Timer1
    {
        private static System.Timers.Timer aTimer;
    
        public static void Main()
        {
   
            // Create a timer with a fourty second interval.
            aTimer = new System.Timers.Timer(40000);
    
            // Hook up the Elapsed event for the timer.
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);    
    
   
            // If the timer is declared in a long-running method, use 
            // KeepAlive to prevent garbage collection from occurring 
            // before the method ends. 
            //GC.KeepAlive(aTimer);
        }
    
        // Specify what you want to happen when the Elapsed event is  
        // raised. 
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //Code that needs repeating every fourty seconds
        }
    }
