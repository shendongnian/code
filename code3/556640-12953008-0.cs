    class MyObservableCollection<T> : ObservableCollection<T>
    {
        private bool _notifyCollectionChanged = true;
        protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (_notifyCollectionChanged)
                base.OnCollectionChanged(e);
        }
        public void AddRange(IEnumerable<T> collection)
        {
            _notifyCollectionChanged = false;
            foreach (T element in collection)
                Add(element);
            _notifyCollectionChanged = true;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
