    public ObservableCollection<Load> Loads { get; set; }
    public LoadFactory()
    {
        Loads = new ObservableCollection<Load>();
        AddLoad(new Load(15));
        AddLoad(new Load(12));
        AddLoad(new Load(25));
    }
