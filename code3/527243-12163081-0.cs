     private static void Main(string[] args)
        {
            var thread = new Thread(
                () =>
                    {
                        var timer = new System.Timers.Timer
                            {
                                Interval = 10000, //10s
                                AutoReset = false, //only raise the elapsed event once
                            };
                        timer.Elapsed += timer_Elapsed;
                        timer.Start();
                        while (true)
                        {
                            Console.WriteLine("Running...");
                            Thread.Sleep(1000); //Always put a thread to sleep when its blocking so it does not waste CPU cycles.
                        }
                    });
            thread.Start();
        }
        private static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //thread is running for more that X (10s) amount of seconds
            Console.WriteLine("Timer elapsed");
        }
