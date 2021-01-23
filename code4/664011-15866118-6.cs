    public Window()
    {
        // Initialize
        this.InitializeComponent();
        // Populate list
        this.listView.Items.Add(new MyItem { Id = 1, Name = "David" });
    }
