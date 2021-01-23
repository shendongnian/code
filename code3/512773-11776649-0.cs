        public ObservableObject SelectedOne 
        {
            get { return _selectedOne; }
            set 
            {
                if(_selectedOne != value)
                _selectedOne = value;
                OnPropertyChanged("SelectedOne ");//<-- otherwise the view dont know that the SelectedItem changed
            }
        }
