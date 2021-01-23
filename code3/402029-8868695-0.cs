    ObservableCollection<YourType> myCollection = new ObservableCollection<YourType>();
    ...
    
    public ObservableCollection<YourType> MyCollection
    {
    	get
    	{
    		return this.myCollection;
    	}
    	
    	set
    	{
    		if (value != this.myCollection)
    		{
    			this.myCollection = value;
    			this.RaisePropertyChanged("MyCollection");
    		}
    	}
    }
    ...
    // Following lines of code will update the UI because of INotifyCollectionChanged implementation
    this.MyCollection.Remove(...)
    this.MyCollection.Add(...)
    
    // Following line of code also updates the UI cause of RaisePropertyChanged
    this.MyCollection = new ObservableCollection<YourType>(this.MyCollection.Where(z => z.Price == 45));
