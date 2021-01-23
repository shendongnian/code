    public class Base
    {
        public virtual void DoSomething()
        { . . . }
    }
    public class Derived
    {
        public override void DoSomething()
        { 
            throw new InvalidOperationException("Method not valid for Derived");
        }
    }
