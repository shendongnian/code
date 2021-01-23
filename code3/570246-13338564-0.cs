    // http://stackoverflow.com/questions/13302933/how-to-avoid-firing-observablecollection-collectionchanged-multiple-times-when-r
    // http://stackoverflow.com/questions/670577/observablecollection-doesnt-support-addrange-method-so-i-get-notified-for-each
    public class ObservableCollectionFast<T> : ObservableCollection<T>
    {
        public ObservableCollectionFast()
            : base()
        {
        }
        public ObservableCollectionFast(IEnumerable<T> collection)
            : base(collection)
        {
        }
        public ObservableCollectionFast(List<T> list)
            : base(list)
        {
        }
        public virtual void AddRange(IEnumerable<T> collection)
        {
            if (collection.IsNullOrEmpty())
                return;
            foreach (T item in collection)
            {
                this.Items.Add(item);
            }
            this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            // Cannot use NotifyCollectionChangedAction.Add, because Constructor supports only the 'Reset' action.
        }
        public virtual void RemoveRange(IEnumerable<T> collection)
        {
            if (collection.IsNullOrEmpty())
                return;
            bool removed = false;
            foreach (T item in collection)
            {
                if (this.Items.Remove(item))
                    removed = true;
            }
            if (removed)
            {
                this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
                this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
                this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                // Cannot use NotifyCollectionChangedAction.Remove, because Constructor supports only the 'Reset' action.
            }
        }
        public virtual void Reset(T item)
        {
            this.Reset(new List<T>() { item });
        }
        public virtual void Reset(IEnumerable<T> collection)
        {
            if (collection.IsNullOrEmpty() && this.Items.IsNullOrEmpty())
                return;
            // Step 0: Check if collection is exactly same as this.Items
            if (IEnumerableUtils.Equals<T>(collection, this.Items))
                return;
            int count = this.Count;
            // Step 1: Clear the old items
            this.Items.Clear();
            // Step 2: Add new items
            if (!collection.IsNullOrEmpty())
            {
                foreach (T item in collection)
                {
                    this.Items.Add(item);
                }
            }
            // Step 3: Don't forget the event
            if (this.Count != count)
                this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
