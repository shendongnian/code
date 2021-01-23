        // This is your private variable and its public property
        private double _myWidth;
        public double MyWidth
        {
            get { return _myWidth; }
            set { SetField(ref _myWidth, value, "MyWidth"); } // You could use "set { _myWidth = value; }", but this is cleaner. See SetField<T>() method below.
        }
        // This is the implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        // Prevents your code from accidentially running into an infinite loop in certain cases
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
