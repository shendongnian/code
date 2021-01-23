    public class TaskViewModel {
      public TaskViewModel ()
      {
         this.Activities = new List<ActivityViewModel>();
       }
      public int TaskId { get; set; }
      public string TaskSummary { get; set; }
      public string TaskDetail { get; set; }
      public virtual IList<ActivityViewModel> Activities { get; set; }
    }
    public class ActivityViewModel{
      public ActivityViewModel()
      {        
      }
      //Activity stuff goes here
      //No reference to Tasks here!!
    }
