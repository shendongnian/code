        set
        {
            _selectedTabIndex = value;
            if (_selectedTabIndex == 0)
            {
                _readOnlyArray = ReadOnlyArrays.ReadOnlyColumnArrays.LoanerItemsSelect;
            }
            else if (_selectedTabIndex == 1)
            {
                _readOnlyArray = ReadOnlyArrays.ReadOnlyColumnArrays.CustomerSelect;
            }
            else if (_selectedTabIndex == 2)
            {
                _readOnlyArray = ReadOnlyArrays.ReadOnlyColumnArrays.JobSelect;
            }
         
            //Your helper method from base class calling          
            // INotifyPropertyChanged.PropertyChanged event
            this.RaisePropertyChanged("ReadOnlyArray");
        }
