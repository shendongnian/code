    static void Main(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Interval = 3 * 60 * 1000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            Console.WriteLine("Press return to exit");
            Console.ReadLine();
            GC.KeepAlive(timer); //Can't decide if this is needed or not
        }
