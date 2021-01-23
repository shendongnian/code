    class Timer
    {
        private DateTime startingTime;
        // stores starting time of code being tested
        private TimeSpan duration;
        // stores duration of code being tested
        public void startTime()
        {
            GC.Collect();   // force garbage collection
            GC.WaitForPendingFinalizers();
            /* wait until all heap contents finalizer methods have completed for removal of contents to be permanent */
            startingTime = DateTime.Now;
            // get current date/time
        }
        public void stopTime()
        {
            // .Subtract: TimeSpan subtraction
            duration = DateTime.Now.Subtract(startingTime);
        }
        public TimeSpan result()
        {
            return duration;
        }
    }
