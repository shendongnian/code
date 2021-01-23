    public static class Extensions
    {
        public static T First<T>(this ObservableCollection<T> observableCollection)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(observableCollection);
            var enumerator = view.GetEnumerator();
            enumerator.MoveNext();
            T firstElement = (T)enumerator.Current;
            return firstElement;
        }
    }
