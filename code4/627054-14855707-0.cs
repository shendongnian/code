    static void ObservableEmployees_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                     case NotifyCollectionChangedAction.Add:
                        Console.WriteLine("New item {0} added in the collection",e.NewItems[0].ToString());
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        Console.WriteLine("Old item {0} removed in the collection", e.OldItems[0].ToString());
                        break;
                    case NotifyCollectionChangedAction.Move:
                        Console.WriteLine("item {0} is moved", e.NewItems[0].ToString());
                        break;
                    case NotifyCollectionChangedAction.Replace:
                        Console.WriteLine("item{0} is replacced by item{1}.", e.OldItems[0].ToString(), e.NewItems[0].ToString());
                        break;
                    case NotifyCollectionChangedAction.Reset:
                        Console.WriteLine("itme{0} is reset.", e.OldItems[0].ToString());
                        break;
