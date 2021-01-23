    public Double MyDouble
    {
    	get { return _MyDouble; }
    	set
    	{
    		_MyDouble = value;
    
    		RaisePropertyChanged(nameof(MyDouble));
    	}
    }
