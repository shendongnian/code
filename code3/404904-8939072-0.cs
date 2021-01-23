    public abstract class BaseClass
    {
        // All your exising class declaration here
        public virtual object BindingSource
        {
            get
            {
                // By default, a BaseClass is not valid as a binding source
                return null;
            }
        }
        public virtual object SecondBindingSource
        {
            get
            {
                // By default, a BaseClass is a valid Second Binding source
                return this;
            }
        }
    }
    public class DerivedA : BaseClass
    {
        // All your exising class implementation here
        public override object BindingSource
        {
            get
            {
                // For DerivedA, the data sourse is itself.
                // other classes might have their own implementations.
                return this;
            }
        }
        // No need to override SecondBindingSource as the BaseClass one works as expected.
    }
