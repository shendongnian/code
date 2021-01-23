    public class Quantities
    {
        private readonly string _unit;
        private int _quant;
        public Quantities(string unit)
        {
            if(unit == null) throw new ArgumentNullException("unit");
            _unit = unit;
        }
        public int Quant
        {
            get { return _quant; }
            set
            {
                if (Unit == "K")
                {
                    _quant = value / 1000;
                }
                else
                {
                    _quant = value;
                }
            }
        }
        public string Unit { get { return _unit; } }
    }
