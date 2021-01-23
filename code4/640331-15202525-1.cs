    class MyClass
    {
        private readonly Dictionary<Beep, string> _stuff = new Dictionary<Beep, string>();
    
        public string this[Beep beep]
        {
            get { return _stuff[beep]; }
            set { _stuff[beep] = value; }
        }
    }
