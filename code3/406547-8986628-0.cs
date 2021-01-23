        public YourViewModel()
        {
            ...
            YourCollection.CollectionChanged += YourCollection_CollectionChanged; 
            ...
        }
        private void YourCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs args)
        {
            if (args.OldItems != null)
                foreach(var oldItem in args.OldItems)
                    oldItem.PropertyChanged -= YourItem_PropertyChanged;
    
            if (args.NewItems != null)
                foreach(var newItem in args.NewItems)
                    newItem.PropertyChanged += YourItem_PropertyChanged;
        }
        private void Youritem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs args)
        {
            IsDirty = true;
        }
