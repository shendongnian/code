    class ExampleClass : INotifyPropertyChanged
    {
        private static int _MinimumLength = 5;
        public int MinimumLength
        {
            get
            {
                return _MinimumLength;
            }
            set
            {
                if (_MinimumLength != value)
                {
                    _MinimumLength = value;
                    OnPropertyChanged("MinimumLength");
                    OnPropertyChanged("length");
                }
            }
        }
        ...
    }
