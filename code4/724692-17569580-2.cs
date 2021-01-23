    public IList SelectedCultures
    {
    	get { return _selectedCultures; }
    	set
    	{
    	    _selectedCultures = value;
            OnPropertyChanged("SelectedCultures");
    	}
    }
