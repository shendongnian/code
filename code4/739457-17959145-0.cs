        interface IJob
        {
            //add some functionality if needed
        }
    
        public class Job<T>:IJob
        {
            public int ID { get; set; }
            public Task<T> Task { get; set; }
            public TimeSpan Interval { get; set; }
            public bool Repeat { get; set; }
            public DateTimeOffset NextExecutionTime { get; set; }
          
    
            public Job<T> RunOnceAt(DateTimeOffset executionTime)
            {
                NextExecutionTime = executionTime;
                Repeat = false;
                return this;
            }
        }
        List<IJob> x = new List<IJob>();
        x.Add(new Job<string>());
