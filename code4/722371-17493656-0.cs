        ObservableCollection<string> myCollection = new ObservableCollection<string>();
        void Init()
        {
            myCollection.CollectionChanged +=myCollection_CollectionChanged;
        }
        void myCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            myCollection.CollectionChanged -= myCollection_CollectionChanged;
            foreach (string str in e.NewItems)
            {
                myCollection[myCollection.IndexOf(str)] = str.Trim();
            }
            myCollection.CollectionChanged += myCollection_CollectionChanged;
        }
