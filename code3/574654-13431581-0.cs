    void ContextSelectedItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
    //Need to unsubscribe from the events so we don't override the transfer
    UnsubscribeFromEvents();
         
    //Move items from the selected items list to the list box selection
    Transfer(SelectedItems as IList,  AssociatedObject);
         
    //subscribe to the events again so we know when changes are made
    SubscribeToEvents();
    }
    public static void Transfer(IList source,  ListBox lb)
    {
        if (source == null || lb== null || !lb.SelectedItems.Any())
            return;
    }
    lb.SetSelectedItems(source)
    }
