    private int _myInt;
    public int MyInt
    {
        get { return _myInt; } 
        set
        {
            if(_myInt == value)
                return;
    
            _myInt = value;
            RaisePropertyChanged("MyInt");
        }
    }
    
    private void RaisePropertyChanged(string propertyName)
    {
    	//if the fastmode is checked, do not allow the PropertyChanged event to be fired.
    	if(FastModeChk.Checked)
    	return;
    
    	var handler = PropertyChanged;
    	if(handler != null)
    		handler(this, new PropertyChangedEventArgs(propertyName);
    }
