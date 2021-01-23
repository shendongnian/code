    public partial class YourEntity
    {
       public Guid ID { get; set;}    
       public YourEntity()
       {
          ID = Guid.NewGuid();
       }
    }
 
