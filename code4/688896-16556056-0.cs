    public SomeClass {
        private const int MaxLength = 20; // for example
        private String _theString;
    
        public String CappedString {
            get { return _theString; }
            set {
                _theString = value != null
                    ? value.Substring(0, MaxLength)
                    : null;
            }
        }
    }
