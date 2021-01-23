    class MyObservableDictionary<T, U> : INotifyCollectionChanged, IEnumerable
    {
        Dictionary<T, U> items = new Dictionary<T,U>();
        public void Add(T key, U value)
        {
            this.items.Add(key, value);
            
            // Update any listeners
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        
        // This is from implementing INotifyCollectionChanged
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        // This is from implementing IEnumerable
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            // Dump the entire collection into a 'yield return'. C# will automatically
            // build an enumerator class from it.
            foreach (KeyValuePair<T, U> item in items)
                yield return item;
        }
    }
