            private CustomObject _selectedCustomObject;
    
            public ObservableCollection<CustomObject> CustomObjects
            {
                get
                {
                    return new ObservableCollection<CustomObject>();
                }
            }
    
            public CustomObject SelectedCustomObject
            {
                get { return _selectedCustomObject; }
                set
                {
                    if (_selectedCustomObject== value)
                    {
                        return;
                    }
    
                    _selectedCustomObject= value;
                    PropertyChanged.Raise(this, x => x.SelectedCustomObject);
                }
            }
