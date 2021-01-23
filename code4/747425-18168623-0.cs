    public enum JobStatus
    {
        Started,
        InProgress,
        Completed
    }
    
    
    public class Job
    {
       public JobStatus GetStatus()
       {
           // Obviously, you would probably check some conditions here
           // and return the proper status. 
           return JobStatus.Started;
       }
    }
