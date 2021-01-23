    public class A 
    {
       public virtual bool ThisIsMe(A objectToCheck){}
       public virtual object GetData{}
    }
    
    public class B : A 
    {
       public override  bool ThisIsMe(A objectToCheck)
       {   
          return objectToCheck is B;
       }
       public override object GetData()
       {
          return this.Foo;
       }
    }
    
    public class C : A 
    {
       public override  bool ThisIsMe(A objectToCheck)
       {   
          return objectToCheck is B;
       }
       public override object GetData()
       {
          return this.Bar;
       }
    }
