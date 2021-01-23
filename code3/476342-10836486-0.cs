    public abstract class A
    {
         public ISomeInterface AMethod{get;}
    }
    
    public abstract class A<T> : A
    {
         public T GetT{get;}
    }
