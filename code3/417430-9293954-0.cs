        public object SelectedValue
        {
            get { return _selectedValue; }
            set 
            { 
                _selectedValue = value;
                OnPropertyChanged("SelectedValue");
            }
        }
        private object _selectedValue;
