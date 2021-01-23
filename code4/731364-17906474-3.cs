    public ICollectionViewLiveShaping WorkersEmployed { get; set; }
    
    ICollectionView workersCV = new CollectionViewSource
                             { Source = GameContainer.Game.Workers }.View;
    
    ApplyFilter(workersCV);
    
    WorkersEmployed = workersCV as ICollectionViewLiveShaping;
    if (WorkersEmployed.CanChangeLiveFiltering)
    {
        WorkersEmployed.LiveFilteringProperties.Add("EmployerID");
        WorkersEmployed.IsLiveFiltering = true;
    }
