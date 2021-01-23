    [Browsable(false)]
    public List<MyObject> Items
    {
        get { return this.oItems; }
    }
    // this (below) is the one the PropertyGrid will use
    [DisplayName("Items")]
    public ReadOnlyCollection<MyObject> ReadOnlyItems
    {
        get { return this.oItems.AsReadOnly(); }
    }
