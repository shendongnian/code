    private ObservableCollection<TestClass> dataItems= new ObservableCollection<TestClass>();
    public ObservableCollection<TestClass> DataItems
    {
        get { return this.dataItems; }
        set 
        { 
             this.dataItems = value; 
             base.OnPropertyChanged("DataItems");
        }
    }
