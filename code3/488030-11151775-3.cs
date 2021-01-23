    internal ObservableCollection<DataObject> BindingTest
    {
        get
        {
            ObservableCollection<DataObject> collection = new ObservableCollection<DataObject>();
            for (int counter = 0; counter < 5; counter++)
            {
                DataObject item = new DataObject ();
                item.Header = " ... Header ... ";
                item.Content = " ... Content ... ";
                collection.Add(item );
            }
    
                return collection;
        }
    }
