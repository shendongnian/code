    public void HookCollection(ObservableCollection<int> dest, ObservableCollection<int> source)
       {
        source.CollectionChanged += new NotifyCollectionChangedEventHandler(delegate(object sender, NotifyCollectionChangedEventArgs e)
            {
                // Apply the same changes to the destination collection
                if (e.Action == NotifyCollectionChangedAction.Reset)
                {                   
                    this.reset();
                }
                if (e.NewItems != null)
                {
                    foreach (int o in e.NewItems)
                    {
                        dest.Add(o);
                    }
                }
                if (e.OldItems != null)
                {
                    foreach (int o in e.OldItems)
                    {
                        dest.Remove(o);
                    }
                }  
            });        
        }
 
