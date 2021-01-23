    public event NotifyCollectionChangedEventHandler CollectionChanging;
    protected override void ClearItems()
    {
        if (this.Items.Count > 0)
        {
            this.OnCollectionChanging(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        base.ClearItems();
    }
    protected virtual void OnCollectionChanging(NotifyCollectionChangedEventArgs eventArgs)
    {
        if (this.CollectionChanging != null)
        {
            this.CollectionChanging(this, eventArgs);
        }
    }
