    public abstract class A
    {
        protected double _field;
        protected A()
        {
            InitializeField();
        }
        protected abstract void InitializeField();
        public double SquaredField { get { return _field * _field; } }
    }
    public class B : A
    {
        protected override void InitializeField()
        {
            // Initialize...
        }
    }
