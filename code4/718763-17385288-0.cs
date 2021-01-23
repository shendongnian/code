    public class ObservableSortedSet<T> : INotifyCollectionChanged, ISet<T>
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        private readonly SortedSet<T> _sortedSet;
        public ObservableSortedSet()
        {
            _sortedSet = new SortedSet<T>();
        }
        public bool Add(T item)
        {
            bool result = _sortedSet.Add(item);
            OnCollectionChanged(NotifyCollectionChangedAction.Add);
            return true;
        }
        private void OnCollectionChanged(NotifyCollectionChangedAction action)
        {
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(action));
        }
        // all the rest of ISet implementation goes here...
    }
