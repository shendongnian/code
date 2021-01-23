        private object _property;
        public object Property
        {
            get { return _property; }
            set
            {
                if (_property != value)
                {
                    _property = value;
                    RaisePropertyChanged("Property");
                }
            }
        }
