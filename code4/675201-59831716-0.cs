    public Window()
    {
          this.DataContext = this;
          InitializeComponent();
    }
    public string Name {get;set;}
    public ObservableCollection<ListviewItemDataModel> lv_items {get;set;} = new ObservableCollection<ListviewItemDataModel>();
