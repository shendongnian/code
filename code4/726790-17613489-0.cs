    public interface Inf
    {
       string Info
       {
         get;      
       }
    }
    
    public class BaseClass : Inf
    {
       public virtual string Info
       {
          get { return "Something"; }
       }
    }
    
    public class SubClass : BaseClass 
    {    
       public override string Info
       {
          get { return "Something else"; }
       }
    }
