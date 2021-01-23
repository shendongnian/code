    //no direct implementors; unfortunately an "abstract interface" is kind of redundant
    //and there's no way to tell the compiler that a class inheriting from this base 
    //interface is wrong,
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
    
