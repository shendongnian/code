    public interface IFoo
    {
        bool Foo(Person a, Person b);
    }
    
    public abstract class IFooBase : IFoo
    {
        public bool Foo(Person a, Person b)
        {
            if (a.IsAmateur || b.IsAmateur) // common logic
              return true;
            return false;
        }
    }
    
    public class KungFoo : IFooBase
    {
    
    }
    
    public class KongFoo : IFooBase
    {
        public override bool Foo(Person a, Person b)
        {
            // Some other logic if the common logic doesn't work for you here
        }
    }
