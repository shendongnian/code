        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(this, new PropertyChangedEventArgs("Name")); }
        }
