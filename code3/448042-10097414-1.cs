    // Define other methods and classes here
    public abstract class BaseClass
    {
        protected BaseClass()
        {
            // some logic here
        }
        protected Object Parameter {get; private set;}    
        public virtual void Initialize(Object parameter)
        {
            Parameter = _parameter;
            // some more logic
        }
    }
