    public abstract class A
    {
        public static A Create()
        {
            return new B();
        }
        
        public abstract void DoSomething();
    }
    public class B : A
    {
        public override void DoSomething()
        {
            // do nothing.
        }
    }
