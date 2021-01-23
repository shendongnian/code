    public class Base<T> where T : IDataItem
    {
        public abstract IEnumerable<SynchronizeItem<T>> Sync(
            IEnumerable<SynchronizeItem<IDataItem>> 
            clientSyncItems);
    }
