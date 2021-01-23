    public ObservableCollection<GroupOfTasks> Groups { get; private set; }
    
    public void LoadData()
    {
        try
        {
            Groups.Clear();
            (...)
            Groups = (from t in tasks
                      group t by t.DueDate into g
                      select new GroupOfTasks { Date = g.Key, Items = g.ToList() }).ToList();
        }
    }
