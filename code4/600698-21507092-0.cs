    public class BaseEntity
    {
       public int Id {get; set;}
       public States State { get; set; }
       public bool MustDelete {get; set;} 
       public enum States
       {
         Unchanged, 
         Added,
         Modified,
         Deleted
       }
    }
