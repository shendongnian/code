    public interface IRevision
    {
        // Include any members which don't depend on TRevisionType
    }
    public interface IRevision<TRevisionType> : IRevision
    {
        // The rest
    }
