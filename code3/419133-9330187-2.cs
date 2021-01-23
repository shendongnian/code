    public PaginatedList<T>(IQueryable<T> source, int pageIndex, int? pageSize)
    {
        PageIndex = pageIndex; //global variable
        PageSize = pageSize ?? source.Count(); //global variable
        TotalCount = source.Count(); //global variable
        TotalPages = (int)Math.Ceiling(TotalCount /(double)PageSize); //global variable
        this.AddRange(source.Skip(PageIndex*PageSize).Take(PageSize));
    }
