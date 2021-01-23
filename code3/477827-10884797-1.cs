    public MyControl()
    {
        InitializeComponent();
        ((INotifyCollectionChanged)listView.Items).CollectionChanged +=  ListView_CollectionChanged;
    }
    private void ListView_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)     
    {
        if (e.Action == NotifyCollectionChangedAction.Add)
        {
          // scroll the new item into view   
          listView.ScrollIntoView(e.NewItems[0]);
        }
    }
