    string IAppContextItem.Key
    {
        get { return key + "A"; }
        set { key = value; }
    }
    
    string IAppContextItem<T>.Key
    {
        get { return key + "B"; }
        set { key = value; }
    }
