        private decimal _myProperty;
        public decimal MyProperty
        {
            get { return _myProperty; }
            set {
                if (value <= 99999999) //for 8 
                {
                    _myProperty = Math.Round(value,4);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }
