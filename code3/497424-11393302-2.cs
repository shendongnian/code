    public interface IBaseInterface{
      int PropertyA{get;set;}
    }
    
    public abstract class BaseClass : IBaseInterface{
      public int PropertyA{
        get{ return this.propertyA;}
        set {this.propertyA = value;}
       }
    }
