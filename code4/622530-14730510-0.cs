    class MyObservableDictionary<T, U> : INotifyCollectionChanged, IEnumerable
    {
        Dictionary<T, U> items = new Dictionary<T,U>();
        public void Add(T key, U value)
        {
            this.items.Add(key, value);
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (KeyValuePair<T, U> item in items)
                yield return item;
        }
    }
