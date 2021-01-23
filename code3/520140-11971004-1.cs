    public abstract class A
    {
        private readonly double _field;
    
        public double SquaredField { get { return _field * _field; } }
        protected A(double field)
        {
            _field = field;
        }
    }
