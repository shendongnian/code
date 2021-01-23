    public class Lockbox
    {
        public Lockbox(string lockbox, int pollingInterval)
        {
            this.lockbox = lockbox;
            this.polling_interval = pollingInterval;
        }
    
        public string lockbox { get; set; }
        public int polling_interval { get; set; }
    }
