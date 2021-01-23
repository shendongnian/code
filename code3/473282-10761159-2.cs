    public class MyParam
    {
       public EntityContext one { get; set; }
       public Nullable<int> two { get; set; }
       .....
    
       public IQueryable<ThingRequest> GetThings()
       {...}
    }
