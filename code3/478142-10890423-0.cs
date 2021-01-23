    var courses = query.ToList().Select(c => new SomeModel
      {
          Status = c.GetStatus();
      });
    
    public class SomeModel 
    {
       ...
       
       public Status GetStatus()
       {
          if(this.someQuery())
          { 
              return Status.Completed;
          }
          else if(this.someOtherQuery())
          {
               return Status.InComplete;
          }
          else if(this.someOtherQuery1())
          {
              return Status.Ok;
          }
          ...
       }
    }
