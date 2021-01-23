    public GridControl()
    {
        InitializeComponent();
        GridData gd = new GridData();
        gd.UpdateResults();
        this.DataContext = gd;
    }
