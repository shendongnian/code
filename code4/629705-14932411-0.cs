    abstract class Base
    {
           public void Method1()
           { 
              //some code
           } // No need to override
           public abstract void Method2(); // must be overriden
           public virtual void Method3()
           {
               // some code
           } // Not necessarily be overriden
    }
    
    class Derived : Base
    {
    }
