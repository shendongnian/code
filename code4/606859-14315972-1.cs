    public class Months
    {
        private readonly IDictionary<string, double> _backfiends;
        public double Jan
        {
            get { return _backfiends["Jan"]; }
            set { _backfiends["Jan"] = value; }
        }
            
        public IDictionary<string, double> Backfields
        {
            get { return _backfiends; }   
        }
        public Months()
        {
            _backfiends = new Dictionary<string, double>();
            _backfiends["Jan"] = 0;
        }
    }
