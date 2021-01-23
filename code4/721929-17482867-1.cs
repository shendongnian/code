    static void Main(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            timer.Interval = 3 * 60 * 1000;
            timer.Enabled = true;
            Console.WriteLine("Press return to exit");
            Console.ReadLine();
            GC.KeepAlive(timer); //Can't decide if this is needed or not
        }
