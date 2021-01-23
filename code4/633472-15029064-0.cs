    public void AddRange(IEnumerable<T> items)
    {
        isInAddRange = true;
        foreach (T item in items)
        {
            if (item != null)
            {
                Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
                    {
                        Add(item);
                    }));
            }
        }
        isInAddRange = false;
        var e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,items.ToList());
        Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
        {
            base.OnCollectionChanged(e);
        });
    }
