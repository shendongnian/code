    internal sealed class CompositeObservableCollection<T> : ObservableCollection<T>
    {
        public CompositeObservableCollection(INotifyCollectionChanged subCollection1, INotifyCollectionChanged subCollection2)
        {
            AddItems((IEnumerable<T>)subCollection1);
            AddItems((IEnumerable<T>)subCollection2);
            subCollection1.CollectionChanged += OnSubCollectionChanged;
            subCollection2.CollectionChanged += OnSubCollectionChanged;
            void OnSubCollectionChanged(object source, NotifyCollectionChangedEventArgs args)
            {
                switch (args.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        AddItems(args.NewItems.Cast<T>());
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        RemoveItems(args.OldItems.Cast<T>());
                        break;
                    case NotifyCollectionChangedAction.Reset:
                        Clear();
                        AddItems((IEnumerable<T>)subCollection1);
                        AddItems((IEnumerable<T>)subCollection2);
                        break;
                }
            }
            void AddItems(IEnumerable<T> items)
            {
                foreach (var me in items)
                    Add(me);
            }
            void RemoveItems(IEnumerable<T> items)
            {
                foreach (var me in items)
                    Remove(me);
            }
        }
    }
