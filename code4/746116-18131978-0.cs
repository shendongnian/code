        void MyObservableCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Reset)
            {
                if (MyObservableCollection.Count == 0)
                {
                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            MyObservableCollection.Add(new MyItem());
                        }), null);
                }
            }
        }
