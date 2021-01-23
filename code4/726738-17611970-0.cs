        private double _value;
        public double Value
        {
            [DebuggerStepThrough]
            get { return _value; }
            [DebuggerStepThrough]
            set
            {
                if (Math.Abs(value - _value) > Double.Epsilon)
                {
                    _value = value;
                    OnPropertyChanged("Value");
                }
            }
        }
