    abstract class Base<T>
        where T : Base<T>
    {
       public abstract T GetObj();
    }
    
    class Derived : Base <Derived>
    {
       public Derived() { }
    
       public override Derived GetObj()
       {
           return new Derived();
       }
    }
