    public class JobManager
    {
        private static Queue<JobData> _queue;
        
        public static void AddJob(string value)
        {
            //TODO: validate
            
            _queue.push(new JobData(value));
        }
    
        private class JobData
        {
            public string Path { get; set; }
            public short TTL { get; set; }
    
            public JobData(string value)
            {
                this.Path = value;
                this.TTL = DEFAULT_TTL;
            }
        }
    
    }
