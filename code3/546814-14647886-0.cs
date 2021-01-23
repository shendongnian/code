    // Hook up CollectionChanged event in Constructor
    public MyViewModel()
    {
        Products = new ObservableCollection<Product>();
        MyItemsSource.CollectionChanged += Products_CollectionChanged;
    }
    // Add/Remove PropertyChanged event to Product item when the collection changes
    void Products_CollectionChanged(object sender, CollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
            foreach(Product item in e.NewItems)
                item.PropertyChanged += Product_PropertyChanged;
    
        if (e.OldItems != null)
            foreach(Product item in e.OldItems)
                item.PropertyChanged -= Product_PropertyChanged;
    }
    
    // When LineTotal property of Product changes, re-calculate Total
    void Product_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "LineTotal")
        {
            TotalAmount = products.Sum(p => p.LineTotal);
            // Or if calculation is in the get method of the TotalAmount property
            //onPropertyChanged(this, "TotalAmount");
        }
    }
