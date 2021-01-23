    public interface IDomainObject
    {
       int Id {get;}
    }
    
    public interface IDatabaseDomainObject:IDomainObject { }
    
    public interface ICloudDomainObject:IDomainObject { }
    public class SomeDatabaseEntity:IDatabaseDomainObject
    {
        public int Id{get;set;}
        ... //more properties/logic
    }
    public class SomeCloudEntity:ICloudDomainObject
    {
        public int Id{get;set;}
        ... //more properties/logic
    }
    
