    public class Logger
    {
        private readonly IClock clock;
        public Logger(IClock clock)
        {
            this.clock = clock;
        }
        public void Log(string message)
        {
            Instant timestamp = this.clock.Now;
            // Now log the message with the timestamp... 
        }
    }
