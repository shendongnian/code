    private ObservableCollection<SecondaryItem> _secondaryItems;
    public ObservableCollection<SecondaryItem> SecondaryItems
    {
        get { return _secondaryItems; }
        set { _secondaryItems = value; RaisePropertyChanged(); }
    }
