    public interface ITag
    {
        bool Contains(ITag tag);
    }
    public interface ITag<T> : ITag
        where T : ITag<T>
    {
        bool Contains(T tag);
    }
