    private ObservableCollection<DataItem> dataItems= new ObservableCollection<DataItem>();
    public ObservableCollection<DataItem> DataItems
    {
        get { return this.dataItems; }
        set 
        { 
             this.dataItems = value; 
             base.OnPropertyChanged("DataItems");
        }
    }
