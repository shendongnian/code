    private string _searchString;
    public string SearchString
    {
        get 
        { 
            return _searchString; 
        }
        set
        {
            value = Regex.Replace(value, "[^0-9]", string.Empty);    
    
            // If regex value is the same as the existing value,
            // change value to null to force bindings to re-evaluate
            if (_searchString == value)
            {
                _searchString = null;
                DoNotifyPropertyChanged("SearchString");
            }
             
            _searchString = value;
            DoNotifyPropertyChanged("SearchString");
        }
    }
