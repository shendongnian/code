    // GENERIC base class 
    public abstract class A<T> 
    {
        public abstract T GetMyType ();	
    }
    
    //derived ones 
    public class B : A<B>
    {
       public override B GetMyType ()
       {     
    		return new B();		
       }
    }
    
    
    public class C : A<C>
    {
       public override C GetMyType ()
       {     
          return new C();		
       }
    }
