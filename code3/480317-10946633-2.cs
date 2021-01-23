    public ObservableCollection<ObservableCollection<ContentItemViewModel>> ContentItems
    {
       get { return _contentItems; }
       set { _contentItems = value; // Notify of property change here, this allows you to change the ContentItems reference after view model construction }
    }
    public MyViewModel()
    {
        // Populate content items
        this.ContentItems = new ObservableCollection 
              {
                  new ObservableCollection { new ContentItemViewModel() },
                  new ObservableCollection { new ContentItemViewModel(), new ContentItemViewModel() }
              };
    }
