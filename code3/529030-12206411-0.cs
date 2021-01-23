    public class PerfTester
    {
        private EventWaitHandle _running = new EventWaitHandle(false, EventResetMode.ManualReset, "awesome_Woo");
        private int _count;
    
        public Run(Action actionToRun)
        {
            ParameterizedThreadStart runner = new ParameterizedThreadStart((state) =>
            {
                Action action = state as Action;
                EventWaitHandle run = = new EventWaitHandle(false, EventResetMode.ManualReset, "awesome_Woo", false);
                while(true)
                {
                    run.WaitOne();
                    action();
                    _count++;
                }
            });
    
            Thread runnerThread = new Thread(runner);
            runnerThread.Start(actionToRun);
    
            StopWatch timer = new StopWatch();
            timer.Start();
            _running.Set();
            while(timer.ElapsedSeconds < 120) Thread.Sleep(500);
            _running.Reset();
    
            Console.WriteLine(_count);
        }
    }
