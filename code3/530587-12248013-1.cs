    // GENERIC base class 
    public abstract class A<T> 
    {
        public abstract T GetMyType {get;}	
    }
    
    //derived ones 
    public class B : A<B>
    {
       public override B GetMyType
       {     
          get {
    		return new B();		
          }
       }
    }
    
    
    public class C : A<C>
    {
       public override C GetMyType 
       {     
          get  {
             return new C();		
          }
       }
    }
