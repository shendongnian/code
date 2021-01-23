    public struct Quantity
    {
        private readonly double _Value;
        private readonly string _Unit;
        public Quantity(double value, string unit)
        {
            _Value = value;
            _Unit = unit;
        }
        public double Value
        {
            {
                return _Value;
            }
        }
        public double Unit
        {
            {
                return _Unit;
            }
        }
    }
