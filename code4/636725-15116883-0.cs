    switch (e.Action)
    {
        case NotifyCollectionChangedAction.Add:
            for(int i = 0; i<e.NewItems.Count;i++)
            {
                ClientVM item = e.NewItems[i] as ClientVM;
                item.PropertyChanged += ItemPropertyChanged;
                contexte.ListOfClientsToAdd.Add(item.Client);
            }
            break;
        case NotifyCollectionChangedAction.Remove:
            for(int i = 0; i < e.OldItems.Count; i++)
            {
                ClientVM item = e.OldItems[i] as ClientVM;
                item.PropertyChanged -= ItemPropertyChanged;
                contexte.ListOfClientsToRemove.Add(item.Client);
            }
            break;
    }
