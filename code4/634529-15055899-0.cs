    public class MyObservableCollection<T> : ObservableCollection<T>
    {
        public event EventHandler<NotifyCollectionChangedEventArgs> ItemAdded;
        public MyObservableCollection()
        {
            CollectionChanged += MyObservableCollection_CollectionChanged;
        }
        void MyObservableCollection_CollectionChanged(object sender,            NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                ItemAdded(sender, e);
        }
    }
