    // Some UI component is binded to this collection that is obersvable
    public ObservableCollection<SomeClass> MyCol
    {
    	get
    	{
    		return this.myCol;
    	}
    	
    	set
    	{
    		if (this.myCol != value)
    		{
    			this.myCol = value;
    			this.RaisePropertyChanged("MyCol");
    		}
    	}
    }
    
    public void UpdateList()
    {
    	var info = new MyCoreInstance().GetHardwareInfo();
    	
    	// Now, marshall back to the UI thread to update the collection
    	Application.Current.Dispatcher.Invoke(() =>
    		{
    			this.MyCol = new ObservableCollection(info);
    		});
    }
