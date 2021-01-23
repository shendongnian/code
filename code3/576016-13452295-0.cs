    public event PropertyChangedEventHandler PropertyChanged = delegate {};
    public MyDomainObject MyDomainObject
    {
    	get
    	{
    		return myDomainObject;
    	}
    	set
    	{
    		if(value != myDomainObject)
    		{
    			myDomainObject = value;
    			RaisePropertyChanged("MyDomainObject");
    		}
    	}
    }
    
    private void RaisePropertyChanged(String p)
    {
    	PropertyChanged(this, new PropertyChangedEventArgs(p));
    }
