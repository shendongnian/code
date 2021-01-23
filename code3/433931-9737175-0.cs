    public class SuperObservableCollection<T> : ObservableCollection<T>
    {
        public void SetItems(IEnumerable<T> items)
        {
            suppressOnCollectionChanged = true;
            Clear();
            AddRange(items);
        }
        private bool suppressOnCollectionChanged;
        public void AddRange(IEnumerable<T> items)
        {
            suppressOnCollectionChanged = true;
            if (items != null)
            {
                foreach (var item in items)
                    Add(item);
            }
            suppressOnCollectionChanged = false;
            NotifyCollectionChanged();
        }
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!suppressOnCollectionChanged)
                base.OnCollectionChanged(e);
        }
        public void NotifyCollectionChanged()
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
