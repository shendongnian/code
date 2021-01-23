    public static class GlobalVar
    {
        private static JobsDictionary jobsDictionary = null;
        
        static GlobalVar()
        {
            jobsDictionary = CreateJobsDictionary();
        }
        
        public static JobData Job(string jobCat)
        {
            JobData result;
            
            if (jobsDictionary.TryGetValue(jobCat, out result))
            {
                return result;
            }
            return jobsDictionary[jobCat];
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
