    class ValueViewModel<T>:INotifyPropertyChanged
    {
        private T _value;
        public T Value 
        {
            get{ return _value;}
            set
            {
                _value = value;
                RaisePropertyChanged("Value");
            }
        }
    }
