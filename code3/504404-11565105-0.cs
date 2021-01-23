    public ClioViewModel()
    {
        Harvesters = new ObservableCollection<Harvester>();
        _timer = new Timer((o) => Application.Current.Dispatcher.BeginInvoke(new Action(LoadAllHarvester)), new object(), TimeSpan.FromMilliseconds(1), TimeSpan.FromMinutes(1));
        Groups.Add("Data Warehouse");
    }
