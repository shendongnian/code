    public class DynamicCollection<T> : IEnumerable, INotifyCollectionChanged
    {
        public ICollectionView Collection { get; private set; }
        public delegate List<T> Del();
        private Del query;
        public Del Query
        {
            get
            {
                return query;
            }
            set
            {
                if (query != value)
                {
                    query = value;//set the new query
                    T currentItem = (T)Collection.CurrentItem;//save current item
                    Collection = new PagedCollectionView(Query());//recreate collection with new query
                    Collection.MoveCurrentTo(currentItem);//move current to the previous current (if it doesn't exist, nothing is selected)
                    OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));//Notify colleciton has changed.
                }
            }
        }
        public DynamicCollection()
        {
            Collection = new PagedCollectionView(new List<T>());//empty collection
        }
        public DynamicCollection(IEnumerable<T>collection)
        {
            Collection = new PagedCollectionView(collection);
        }
        public DynamicCollection(Del delegateQuery)
        {
            Query = delegateQuery;
        }
        
        #region IEnumerable Members
        public IEnumerator GetEnumerator()
        {
            return Collection.GetEnumerator();
        }
        #endregion IEnumerable Members
        #region INotifyCollectionChanged Members
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        protected void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            NotifyCollectionChangedEventHandler handler = CollectionChanged;
            if (handler != null)
            {
                CollectionChanged(this, e);
            }
        }
        #endregion INotifyCollectionChanged Members
    }
