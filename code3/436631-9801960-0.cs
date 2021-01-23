    private RelayCommand myCommand;
    
    public ICommand MyCommand
    {
    	get
    	{
    		return this.myCommand;
    	}
    }
    
    ...
    
    // in constructor of the view model:
    this.myCommand = new RelayCommand(this.MyCommandImplementation);
    
    ...
    
    private void MyCommandImplementation()
    {
    	// Save your parameters here from your model
    }
