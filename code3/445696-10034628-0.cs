    public abstract class FooBase
    {
       protected FooBase()
       {
       }
       public virtual int GetSomeThing()
       {
          // ... some generated implementation ...
       }
    }
    
    public partial class Foo
    {
       public Foo() : FooBase()
       {
       }
       // Nothing except the constructor generated in this class.
    }
