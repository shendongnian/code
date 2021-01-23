    public class A 
    {
          public virtual const int Some = 1;
    }
    
    public class B : A
    {
          public override const int Some = 2;
    }
    
    public class C : A
    {
         // No override here!
    }
    
    int valueOfSomeConstant = C.Some;
