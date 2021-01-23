    public Window1()
    {
        this.InitializeComponent();
        var gridView = new GridView();
        this.listView.View = gridView;
        gridView.Columns.Add(new GridViewColumn { 
            Header = "Id", DisplayMemberBinding = new Binding("Id") });
        gridView.Columns.Add(new GridViewColumn { 
            Header = "Name", DisplayMemberBinding = new Binding("Name") });
        this.listView.Items.Add(new MyItem { Id = 1, Name = "Davidwroxy" });
    }
