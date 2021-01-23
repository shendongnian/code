    using System;
    using System.Timers;
    
    public class Timer1
    {
        private static System.Timers.Timer aTimer;
    
        public void Foo()
        {
        }
        public static void Main()
        {
            Foo();
    
            // Create a timer with a two minutes interval.
            aTimer = new System.Timers.Timer(120000);
    
            // Hook up the Elapsed event for the timer.
            aTimer.Elapsed += new ElapsedEventHandler(Foo());
    
            aTimer.Enabled = true;
        }
    
        // Specify what you want to happen when the Elapsed event is  
        // raised. 
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Foo();
        }
    }
