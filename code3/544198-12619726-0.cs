    public abstract class IFoo{
       bool Foo(Person a, Person b){
          if (a.IsAmateur || b.IsAmateur) // common logic
             return true;
       }
       public abstract Object otherFooMethod(Object o);
    }
