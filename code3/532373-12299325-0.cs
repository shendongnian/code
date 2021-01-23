    interface IPagedResult<T>
    {
        int PageCount { get; }
        int TotalItemCount { get; }
        int PageIndex { get; }
        IEnumerable<T> Page {get; }
    }
