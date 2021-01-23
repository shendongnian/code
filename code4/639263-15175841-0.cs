    public class Base<T> 
    {
        public abstract IEnumerable<SynchronizeItem<T>> Sync(
            IEnumerable<SynchronizeItem<IDataItem>> 
            clientSyncItems) where T : IDataItem;
    }
