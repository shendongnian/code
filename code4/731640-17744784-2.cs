    public abstract class BaseEntity
    {
         public EntityTypeEnum EntityType {get;set;}
    }
    
    public enum EntityTypeEnum 
    {
       EntityOne,
       EntityTwo,
       EntityThree
    }
