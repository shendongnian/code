    public interface IBaseInterface{
      public int PropertyA{get;set;}
    }
    
    public abstract class BaseClass : IBaseInterface{
      public override int PropertyA{
        get{ return this.propertyA;}
        set {this.propertyA = value;}
       }
    }
