    private void SubscribeToPlatformChanges()
    {
        ((INotifyCollectionChanged)_PlatformVM.Platforms).CollectionChanged += (s, e) =>
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:   //platforms were added - use e.NewItems
                case NotifyCollectionChangedAction.Add:   //platforms were removed - use e.OldItems
                case NotifyCollectionChangedAction.Reset: //all platforms were removed
            }
        }
    }
