    public static void Main()
        {
            Timer myTimer = new Timer();
            myTimer.Elapsed += new ElapsedEventHandler(DisplayTimeEvent);
            myTimer.Interval = 1000;
            myTimer.Start();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    while (Console.ReadKey().KeyChar != 'q')
                    {
                        // do nothing
                    }
                    break;
                }
            }
        }
