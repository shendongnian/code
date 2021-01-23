    public static class GlobalVar
    {
        private static readonly object syncRoot = new object();
        private static JobsDictionary jobsDictionary = null;
		
        public static JobData Job(string jobCat)
        {
            Initialize();
        
            JobData result;
            
            if (jobsDictionary.TryGetValue(jobCat, out result))
            {
                return result;
            }
            return jobsDictionary[jobCat];
        }
        
        private void Initialize()
        {
            // Double-checked lock.
            if (jobsDictionary == null)
            {
                lock (syncRoot)
                {
                    if (jobsDictionary == null)
                    {
                        jobsDictionary = CreateJobsDictionary();
                    }
                }
            }
        }
        
        private static JobsDictionary CreateJobsDictionary()
        {
            var jobs = new JobsDictionary();
            
            //TODO: get the Data from the Database
            jobs.Add("earnings", "EarningsWhispers", "http://...");
            jobs.Add("stock", "YahooStock", "http://...");
            jobs.Add("functions", "Functions", null);
            
            return jobs;
        }
    }
