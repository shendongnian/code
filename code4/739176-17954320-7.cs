    public ObservableCollection<ViewModelBase> Tabs {get;set;} //Representing each Tab Item
    
    public MainViewModel() //Constructor
    {
        Tabs = new ObservableCollection<ViewModelBase>();
        Tabs.Add(new ViewModel1());
        Tabs.Add(new ViewModel2());
        Tabs.Add(new ViewModel2());
    }
