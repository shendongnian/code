     static void Main(string[] args)
            {
                ReadCountFromFile();
    
                aTimer = new System.Timers.Timer();
                aTimer.Elapsed += new System.Timers.ElapsedEventHandler(aTimer_Elapsed);
                aTimer.Interval = 5000;
                aTimer.Enabled = true;
                Console.WriteLine("Press Enter To Exit The Program\n");
    //Modification starts from here
                AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
                Console.ReadLine();
    //Modification ends from here
            }
