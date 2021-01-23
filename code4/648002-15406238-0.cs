    _db.MyThings.Local.CollectionChanged += MyThingsChanged;
    
    
    public void MyThingsChanged(object sender, NotifyCollectionChangedEventArgs args) 
    {
      if (args.Action == NotifyCollectionChangedAction.Add)
      {
        // Something has been added
      }
    }
