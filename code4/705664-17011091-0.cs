    public bool HasItems {get {return Items.Any(); } }
    
    public void AddItem()
    {
        //...Add Items
        NotifyPropertyChanged("HasItems");
    }
    public void RemoveItem()
    {
        //...Remove Item
        NotifyPropertyChanged("HasItems");
    }
