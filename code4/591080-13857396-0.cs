    jobDetail.JobDataMap["jobSays"] = "Hello World!";
    jobDetail.JobDataMap["myFloatValue"] =  3.141f;
    jobDetail.JobDataMap["myStateData"] = new ArrayList(); 
    
    public class DumbJob : IJob
    {
        public void Execute(JobExecutionContext context)
        {
            string instName = context.JobDetail.Name;
            string instGroup = context.JobDetail.Group;
    
            JobDataMap dataMap = context.JobDetail.JobDataMap;
    
            string jobSays = dataMap.GetString("jobSays");
            float myFloatValue = dataMap.GetFloat("myFloatValue");
            ArrayList state = (ArrayList) dataMap["myStateData"];
            state.Add(DateTime.UtcNow);
    
            Console.WriteLine("Instance {0} of DumbJob says: {1}", instName, jobSays);
        }
    } 
