    public ICollection<DataType> DataAsList {
        get {
            ObservableCollection<DataType> ob = new ObservableCollection<DataType>(Data.Values());
            ob.CollectionChanged += Handles_entryListChanged;
            return ob;
        }
