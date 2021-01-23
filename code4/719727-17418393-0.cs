    public ObservableCollection<item> Records { get; set; }
    
    // Constructor
    public Page3()
    {
        InitializeComponent();
    
        this.Records = new ObservableCollection<item>();
    
        this.items.ItemsSource = this.Records;
    }
    
    public void AddItem()
    {
        // Thanks to the ObservableCollection,
        // the listbox is notified that you're adding a new item to the source collection,
        // and will automatically refresh its contents
        this.Records.Add(new item { Item = DateTime.Now.ToString() });
    }
