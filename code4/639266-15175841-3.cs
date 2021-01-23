    public class Derived : Base<AdItem>
    {
        public override IEnumerable<SynchronizeItem<AdItem>> Sync(
            IEnumerable<SynchronizeItem<AdItem>> 
            clientSyncItems) 
        { ... }
    }
