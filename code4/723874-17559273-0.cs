    public ObservableCollection<DataModel> CombinedData;
    // should become
    public static readonly DependencyProperty CombinedData= DependencyProperty.Register("CombinedData", typeof(ObservableCollection<DataModel>), typeof(DataFilters), new FrameworkPropertyMetadata());
    //and 
    public ObservableCollection<DataModel> CombinedData
    {
        get { return (ObservableCollection<DataModel>)GetValue(CombinedDataProperty); }
        set { SetValue(CombinedDataProperty, value); }
    }
