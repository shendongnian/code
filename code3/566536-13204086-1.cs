    public class CompositeCollection : ObservableCollection<MeClass>
    {
        private ObservableCollection<MeClass> _subCollection1;
        private ObservableCollection<MeClass> _subCollection2;
        public CompositeCollection(ObservableCollection<MeClass> subCollection1, ObservableCollection<MeClass> subCollection2) 
        {
            _subCollection1 = subCollection1;
            _subCollection2 = subCollection2;
            AddSubCollections();
            SubscribeToSubCollectionChanges();
        }
        private void AddSubCollections()
        {
            AddItems(_subCollection1.All);
            AddItems(_subCollection2.All);
        }
        private void AddItems(IEnumerable<MeClass> items)
        {
            foreach (MeClass me in items)
                Add(me);
        }
        private void RemoveItems(IEnumerable<MeClass> items)
        {
            foreach (MeClass me in items)
                Remove(me);
        }
        private void SubscribeToSubCollectionChanges()
        {
            _subCollection1.CollectionChanged += OnSubCollectionChanged;
            _subCollection2.CollectionChanged += OnSubCollectionChanged;
        }
        private void OnSubCollectionChanged(object source, NotifyCollectionChangedEventArgs args)
        {
            switch(args.Action)
            {
                case NotifyCollectionChangedAction.Add:    AddItems(args.NewItems.Cast<MeClass>());
                                                           break;
                case NotifyCollectionChangedAction.Remove: RemoveItems(args.OldItems.Cast<MeClass>());
                                                           break;
                case NotifyCollectionChangedAction.Reset:  Clear();
                                                           AddSubCollections();
                                                           break;
            }
        }
    }
