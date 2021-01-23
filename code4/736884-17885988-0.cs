        private string _description;
        public event PropertyChangedEventHandler PropertyChanged;
    
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description == value)
                    return;
    
                OnPropertyChanged("Description");
                _description = value;
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)            
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
