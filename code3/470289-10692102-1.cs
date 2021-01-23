    public class DumbJob : IJob
    {
        public void Execute(JobExecutionContext context)
        {
            string instName = context.JobDetail.Name;
            string instGroup = context.JobDetail.Group;
    
            // Note the difference from the previous example
            JobDataMap dataMap = context.MergedJobDataMap;
    
            string jobSays = dataMap.GetString("jobSays");
            float myFloatValue = dataMap.GetFloat("myFloatValue");
            ArrayList state = (ArrayList) dataMap.Get("myStateData");
            state.Add(DateTime.UtcNow);
    
            Console.WriteLine("Instance {0} of DumbJob says: {1}", instName, jobSays);
        }
    }
