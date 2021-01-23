    public abstract class A
    {
        protected double _field;
    
        public double SquaredField { get { return _field * _field; } }
    
        // Require any fields that must be initialized in the base class's
        // constructor. If there are a lot of such fields, consider encapsulating
        // them all in their own class, e.g. AArgs.
        protected A(double field)
        {
            _field = field;
        }
    }
    public class B : A
    {
        // You must call a base class constructor as below, because class A
        // no longer has a parameterless constructor to use by default.
        public B(double field)
            : base(field)
        {
        }
    }
