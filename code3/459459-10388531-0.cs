    _listObsComponents.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(ListCollectionChanged);
    
    // ...
 
        void ListCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            /// Work on e.Action here (can be Add, Move, Replace...)
        }
