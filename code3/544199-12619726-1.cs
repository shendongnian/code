    public class KungFoo : IFoo{
       //Foo already implemented
       public Object otherFooMethod(Object o){
          return o;
       }
    }
    public class KongFoo : IFoo
    {
       public bool Foo(Person a, Person b)
       {
           if (a.IsAmateur || b.IsAmateur) // common logic
             return false;
           return !base.Foo();
       }
       
       public Object otherFooMethod(Object o){
          return o;
       }
     }
