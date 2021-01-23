    internal class MyInternalClass : IMyInterface
    {
    }
    public interface IMyInterface
    {            
    }
    public abstract class MyAbstractClass
    {
        protected IMyInterface myField;
        protected MyAbstractClass(IMyInterface required = null)
        {
            myField = required ?? new MyInternalClass();
        }
    }
