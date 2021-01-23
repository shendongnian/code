    public class MyValues
    {
        private readonly Dictionary<string, int> _internalCollection;
        public MyValues()
        {
            _internalCollection = new Dictionary<string, int>();
            // initialize values here (hard coded or **from config file**)
        }
        public int this[string value]
        {
            get
            {
                return _internalCollection[value];
            }
        }
    }
