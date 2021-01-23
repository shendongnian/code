    abstract public class AbstractClass
    {
        abstract public void DoSomething();
    }
    public class BaseClass : AbstractClass
    {
        public sealed override void DoSomething()
        {
            Console.WriteLine("Did something");
        }
    }
