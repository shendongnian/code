        public DynamicLineChartPlotter()
        {
            _HandleCollectionChanged = new NotifyCollectionChangedEventHandler(collection_CollectionChanged);
        }
        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DynamicLineChartPlotter control = (DynamicLineChartPlotter)d;
            IEnumerable oldValue = (IEnumerable)e.OldValue;
            IEnumerable newValue = (IEnumerable)e.NewValue;
            INotifyCollectionChanged collection = e.NewValue as INotifyCollectionChanged;
            INotifyCollectionChanged oldCollection = e.OldValue as INotifyCollectionChanged;
            if (e.OldValue != null)
            {
                control.ClearItems();
            }
            if (e.NewValue != null)
            {
                control.BindItems((IEnumerable)e.NewValue);
            }
            if (oldCollection != null)
            {
                oldCollection.CollectionChanged -= control._HandleCollectionChanged;
                control._Collection = null;
            }
            if (collection != null)
            {
                collection.CollectionChanged += control._HandleCollectionChanged;
                control._Collection = newValue;
            }
        }
        void collection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ClearItems();
            BindItems(_Collection);
        }
        NotifyCollectionChangedEventHandler _HandleCollectionChanged;
        IEnumerable _Collection;
