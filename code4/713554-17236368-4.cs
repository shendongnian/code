    public static class JobManager
    {
        private static Queue<JobData> _queue;
        static JobManager() { Task.Factory.StartNew(() => { StartProcessing(); }); }
        
        public static void AddJob(string value)
        {
            //TODO: validate
            
            _queue.Enqueue(new JobData(value));
        }
        private static StartProcessing()
        {
            while (true)
            {
                if (_queue.Count > 0)
                {
                    JobData data = _queue.Dequeue();
                    if (!process(data.Path))
                    {
                        data.TTL--;
                        if (data.TTL > 0)
                            _queue.Enqueue(data);
                    }
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
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
