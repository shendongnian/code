    public static void Main()
            {
                System.Timers.Timer aTimer = new System.Timers.Timer();
    
                aTimer.Elapsed += delegate(object source, ElapsedEventArgs e) {
                    OnTimedEvent(source, e, "Say Hello");
                };
                // Set the Interval to 5 seconds.
                aTimer.Interval = 1000;
                aTimer.Enabled = true;
    
                Console.WriteLine("Press \'q\' to quit the sample.");
                while (Console.Read() != 'q') ;
            }
    
            // Specify what you want to happen when the Elapsed event is raised.
            private static void OnTimedEvent(object source, ElapsedEventArgs e, string parameter)
            {
                Console.WriteLine("parameter");
            }
