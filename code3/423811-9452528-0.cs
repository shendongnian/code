    ObservableCollection<Paper> listOfPapers =  new ObservableCollection<Paper>();
    listOfPapers.CollectionChanged += new NotifyCollectionChangedEventHandler(listOfPapers_CollectionChanged);
    
    void listOfPapers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
           OnPropertyChanged("IsCheckingPending");
    }
