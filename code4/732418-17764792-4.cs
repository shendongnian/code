    public class TaskSchedulerController
    {
        private Dictionary<string, TaskScheduler> _scedulers;
        public TaskSchedulerController()
        {
            _scedulers = new Dictionary<string, TaskScheduler>();
        }
        public void Add(string name, int priority)
        {
            _scedulers.Add(name, new TaskScheduler(priority));
        }
        public IEnumerable<string> GetJobsOfScheduler(string name)
        {
            if (_scedulers.ContainsKey(name))
            {
                foreach (var job in _scedulers[name])
                {
                    yield return job.ToString();
                }
            }
        }
    }
