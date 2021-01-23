    public class PagingList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public string pagerange { get; set; }
        public int pagingrange { get; set; }
        public PagingList(IQueryable<T> data, int page, int pagesize)
        {
            PageIndex = page;
            PageSize = pagesize;
            TotalCount = data.Count();
            TotalPages = (int)Math.Ceiling(TotalCount /(double)PageSize);
            this.AddRange(data.Skip(PageIndex * PageSize).Take(PageSize));
        }
        //public void GeneratePageRange()
        //{
        //    for (int i = 1; i <= TotalPages; i++)
        //    {
        //        pagingrange = i
        //    }
        //}
        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }
        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }
    }
