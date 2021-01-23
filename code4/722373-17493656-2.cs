        ObservableCollection<string> myCollection = new ObservableCollection<string>();
        void Init()
        {
            myCollection.CollectionChanged +=myCollection_CollectionChanged;
        }
        void myCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            myCollection.CollectionChanged -= myCollection_CollectionChanged;
            //could be a delete / clear / remove at operation
            if (e.NewItems != null)
            {
                for (int i = 0; i < e.NewItems.Count; i++)
                {
                    string str = (string)e.NewItems[i];
                    //the added value could be null
                    if (str != null)
                    {
                        string trimmed = str.Trim();                        
                        if (!trimmed.Equals(str))
                        {
                            myCollection[e.NewStartingIndex + i] = str.Trim();
                        }
                    }
                }
            }
            myCollection.CollectionChanged += myCollection_CollectionChanged;
        }
