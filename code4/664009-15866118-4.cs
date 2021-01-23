    public Window()
    {
        // Initialize
        this.InitializeComponent();
        // Add columns
        var gridView = new GridView();
        this.listView.View = gridView;
        gridView.Columns.Add(new GridViewColumn { 
            Header = "Id", DisplayMemberBinding = new Binding("Id") });
        gridView.Columns.Add(new GridViewColumn { 
            Header = "Name", DisplayMemberBinding = new Binding("Name") });
        // Populate list
        this.listView.Items.Add(new MyItem { Id = 1, Name = "David" });
    }
