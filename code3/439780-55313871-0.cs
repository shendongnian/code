    ViewModel mModel = null;
    public Designer()
    {
        InitializeComponent();
        mModel = new ViewModel();
        this.DataContext = mModel;
    }
    private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        mModel.SelectedItems = dgvMain.SelectedItems;
    }
