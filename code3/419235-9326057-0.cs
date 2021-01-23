    public interface ISomeInterface
    {
        void DoSomething();
    }
    
    public abstract class BaseClass : ISomeInterface
    {
        public abstract void DoSomething();
    }
    
    public class Person : BaseClass
    {
        public override void DoSomething()
        {
            ...
        }
    }
