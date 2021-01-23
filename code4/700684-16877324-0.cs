    private ICollectionView _advFilter;
    
    public MainViewModel()
    {
        // assuming that Adventurers is ObservableCollection<Adventurer>
        _advFilter = CollectionViewSource.GetDefaultView(Adventurers);
    
        AdvNoFilter();
    }
    
    public void ShowEmployedExecute()
    {
        AdvFilter(AdvStatus.Employed);
    }
    
    public void ShowAvailableExecute()
    {
        AdvFilter(AdvStatus.Available);
    }
    
    void AdvFilter(AdvStatus status)
    {
        _advFilter.Filter = adv => ((Adventurer)adv).Status.Equals(status);
        _advFilter.Refresh();
    }
    
    void AdvNoFilter()
    {
        _advFilter.Filter = null;
        _advFilter.Refresh();
    }
