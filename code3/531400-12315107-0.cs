    public class JobService
    {
      private ActivityService activityService;
      
      public JobService(ActivityService activityService)
      {
        this.activityService = activityService;
      }
    
      public Job GetJob(int jobId)
      {
        using(Client client = new Client())
        {
           Job j = client.GetJob(jobId);
    
           j.Activity = this.activityService.Activities
                            .Where(a=>a.ActivityId == j.ActivityId)
                            .FirstOrDefault();
           return j;
        }
      }  
    }
