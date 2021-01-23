    public abstract class BaseClass
    {
        ...
        protected abstract IMyInterface GetInterface();
        ...
    }
    
    public class DerivedClass : BaseClass, IMyInterface
    {
        ...
        protected override IMyInterface GetInterface()
        {
            return this;
        }
        ...
    }
