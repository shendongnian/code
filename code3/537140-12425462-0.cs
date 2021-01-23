    public interface IChangeCollection<T> : IEnumerable<T>
    {
        bool MoreChangesAvailable { get; }
        string SyncState { get; }
    }
