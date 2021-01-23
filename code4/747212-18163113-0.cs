    public interface IPageableQuery<T> : IQueryable<T>
    {
        int TotalPages { get; }
        int TotalItemCount { get; }
        int PageSize { get; }
    }
    public interface IOrderedPageableQuery<T> : IPageableQuery<T>, IOrderedQueryable<T>
    {
    }
