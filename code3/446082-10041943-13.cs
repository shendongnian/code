    public class JobDataCache : IJobData
    {
        readonly object syncRoot = new object();
        Dictionary<string, JobData> cache;
        public void AddJob(string key, JobData data)
        {
            lock (this.syncRoot)
            {
                cache[key] = data;
            }
        }
    }
