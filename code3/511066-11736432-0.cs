            var obd =  Observable.FromEvent<NotifyCollectionChangedEventArgs>(
                ev => obdCollection.CollectionChanged += CheckChanges,ev=> obdCollection.CollectionChanged -= CheckChanges);
       private void CheckChanges(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("new Starting index : "+e.NewStartingIndex);
            Console.WriteLine("Old Starting index : " + e.OldStartingIndex);
            Console.WriteLine("new Items : " + e.NewItems);
            Console.WriteLine("Old Items : " + e.OldItems);
        }
