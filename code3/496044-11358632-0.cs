     class Program
        {
            private static System.Timers.Timer aTimer;
            static int j = 0;
            static int i = 0;
            public static void Main()
            {         
                // Create a timer with a Minute interval.
                aTimer = new System.Timers.Timer(60000);
    
                // Hook up the Elapsed event for the timer.
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    
                // Set the Interval to 1 Minute (60000 milliseconds).
                aTimer.Interval = 60000;
                aTimer.Enabled = true;
    
                Console.WriteLine("Press the Enter key to exit the program.");
                Console.WriteLine(0 + ":" + 0);
                Console.ReadLine();
            }
            
            // Specify what you want to happen when the Elapsed event is 
            // raised.
            private static void OnTimedEvent(object source, ElapsedEventArgs e)
            {            
                j++;
                if (j == 60)
                {
                    Console.WriteLine("break");
                    j = 1;
                    i = i + 1;
                }
                if (i == 24)
                {
                    i = 0;
                }
    
                if (j % 5 != 0 || (j == 0))
                {                              
                    Console.WriteLine(i + ":" + j);
                }
                else if (j % 5 == 0)
                {
                    Console.WriteLine("break");
                }
            }
        }
