    this.ttActivities.Local.CollectionChanged += ttActivitiesChanged;
    
    
    public void ttActivitiesChanged(object sender, NotifyCollectionChangedEventArgs args) 
    {
      if (args.Action == NotifyCollectionChangedAction.Add)
      {
        // Something has been added
      }
    }
