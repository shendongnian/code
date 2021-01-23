    class BatchObservableColleciton<T> : INotifyCollectionChanged, IEnumerable
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        private List<T> _list;
        private List<T> _addedItems;
        public BatchObservableColleciton( ) {
            _list = new List<T>( );
            _addedItems = new List<T>( );
        }
        
        public IEnumerator GetEnumerator( )
        {
            return _list.GetEnumerator( );
        }
        public void Add( T item )
        {
            _list.Add( item );
            _addedItems.Add( item );
        }
        public void commit( ) {
            if( CollectionChanged != null ) {
                CollectionChanged( this, new NotifyCollectionChangedEventArgs(
                    NotifyCollectionChangedAction.Add, _addedItems ) );
            }
            _addedItems.Clear( );
        }
    }
