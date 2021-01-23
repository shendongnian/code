    public class Base
    {
        public virtual void DoSomething()
        { . . . }
    }
    public class Derived : Base
    {
        public override void DoSomething()
        { 
            throw new NotSupportedException("Method not valid for Derived");
        }
    }
