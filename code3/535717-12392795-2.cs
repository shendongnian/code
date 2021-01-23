    public static class ExtensionMethods
    {
        public static ObservableCollection<T> RemoveAll<T>(
            this ObservableCollection<T> collection, Func<T, bool> predicate)
        {
            List<T> collectionAsList = collection.ToList();
            List<T> itemsToRemove = collection.Where(predicate);            
            collectionAsList.RemoveAll(i => itemsToRemove.Contains(i));
            collection = new ObservableCollection<T>(collectionAsList);
            return collection;
        }
    }
