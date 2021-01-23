    public class ObservableKeyedCollection<TKey, TItem> : KeyedCollection<TKey, TItem>, INotifyCollectionChanged
    {
        ...
        Func<TKey,TItem> m_newItemDelegate;
        public ObservableKeyedCollection(Func<TItem, TKey> getKeyForItemDelegate, Func<TKey, TItem> newItemDelegate = null)
            : base()
        {
            ...
            m_newItemDelegate = newItemDelegate;
        }
        public new TItem this[TKey key]
        {
            get
            {
                if (m_newItemDelegate != null && !Contains(key))
                {
                    TItem i = m_newItemDelegate(key);
                    var i_as_inpc = i as INotifyPropertyChanged;
                    if (i_as_inpc != null)
                        i_as_inpc.PropertyChanged += new PropertyChangedEventHandler(AddItemOnChangeHandler);
                    else
                        Add(i);
                    return i;
                }
                return base[key];
            }
            set
            {
                if (Contains(key)) Remove(key);
                Add(value);
            }
        }
        private void AddItemOnChangeHandler(object sender, PropertyChangedEventArgs e)
        {
            (sender as INotifyPropertyChanged).PropertyChanged -= AddItemOnChangeHandler;
            Add((TItem)sender);
        }
