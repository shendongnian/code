    public class Sale
    {
        private int totalCash;
        public int TotalCash
        {
            get { return totalCash; }
        }
        private string codeletters;
        public string Codeletters
        {
            get { return codeletters; }
        }
        private string crncy;
        public string Crncy
        {
            get { return crncy; }
        }
        public Trade(int _totalCash, string _codeletters, string _crncy)
        {
            totalCash = _totalCash;
            codeletters = _codeletters;
            crncy = _crncy;
        }
    }
