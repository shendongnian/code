    public class TaskScheduler : Queue<Job>, IQueue
    {
        public int Priority { get; set; }
    
        public TaskScheduler(int priority)
        {
            Priority = priority;
        }
    
        public void Add(string work, TimeSpan execution)
        {
            Enqueue(new Job { Work = work, Execution = execution });
        }
    
        public Job Get()
        {
            return Dequeue();
        }
    }
    
    public class Job
    {
        public string Work { get; set; }
        public TimeSpan Execution { get; set; }
    
        public override string ToString()
        {
            return string.Format("{0} will be excuted in {1}", Work, Execution);
        }
    }
