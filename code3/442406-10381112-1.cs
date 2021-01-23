    //in main ViewModel
    private Ducument _currentDocument;
        
    public Document CurrentDocument 
    { 
    	get { return _currentDocument; }
    	set
    	{
    		_currentDocument = value;
    		NotifyPropertyChanged("CurrentDocument");
    	}
    }
    
    //stored all loaded documents as collection.
    public ObservableCollection<Document> Documents { get; set; } 
