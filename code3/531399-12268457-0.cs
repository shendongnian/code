    public partial class Job
    {
      [Import]
      public Activity Activity 
      {
        get
        {
          return *ActivityService*.Activities
                      .Where(x=>x.ActivityId==this.ActivityId)
                      .FirstOrDefault();
        }
      }
    }
    
    [Export]
    public class Activity
    {
     ...
    
    }
