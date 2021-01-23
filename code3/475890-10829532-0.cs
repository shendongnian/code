    public PaginatedList(IQueryable<T> source, int pageIndex, int pageSize) {
            .
            .
            .
            this.AddRange(source.Skip((PageIndex -1) * PageSize).Take(PageSize));
        }
    public bool HasPreviousPage {
            get {
                return (PageIndex > 1);
            }
        }
        public bool HasNextPage {
            get {
                return (PageIndex < TotalPages);
            }
        }
