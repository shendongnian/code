    public class FirstModel : MyBaseEntity
    {
    // ...
    public virtual SecondModel SecondModel { get; set; }
    // ...
    }
    
    public class SecondModel : MyBaseEntity
    {
    // ...
    public int Id
    {
        get { return GetPropertyValue<int>("FirstModelID"); }
        set { SetPropertyValue<int>("FirstModelID", value); }
    }
  
    // ...
    }
