    [Flags]
    public enum ProjectStatus
    {
       Undefined = 1 << 0,
       Closed = 1 << 1,
       Opened =1 << 2,
       ToMigrate = 1<<3 
    }
    
    public class Project
    {
       //other properties
       
       public ProjectStatus Status { get; set; }
       
       public bool CanOpen
       {
           get 
           { 
                 return this.Status == ProjectStatus.Opened 
                     || this.Status == ProjectStatus.StatusToMigrate;  
           } 
       }
    }
