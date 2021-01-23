    //Makes sure on a clear, the list of removed items is actually included.
    protected override void ClearItems()
    {
        if( this.Count == 0 ) return;
        List<T> removed = new List<T>(this);
        base.ClearItems();
        base.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, removed));
    }
    protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
    {
        //If the action is a reset (from calling base.Clear()) our overriding Clear() will call OnCollectionChanged, but properly.
        if( e.Action != NotifyCollectionChangedAction.Reset )
            base.OnCollectionChanged(e);
    }
