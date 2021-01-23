    public Page2(Server x, string dev)
    {
        InitializeComponent(); // and don't forget this
        Db_Entities db = new Db_Entities();
        var query1 = (from a in this.db.Servers
                      where a.ServerID.Contains(dev)
                      orderby a.ServerID
                      select a).ToList();
        datagrid1.ItemsSource = query1.ToList();
    } 
