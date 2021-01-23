    public MetaDataViewModel MyMetaDataViewModel { get; set; }
    public MetaDataView MyMetaDataView { get; set; }
    public MainViewModel()
    {
        MyMetaDataViewModel = new MetaDataViewModel();
        MyMetaDataView = new MetaDataView();
        MyMetaDataView.DataContext = MyMetaDataViewModel;
    }
