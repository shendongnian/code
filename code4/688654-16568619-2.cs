    public IQueryable<SomeObject> GetObjects([ViewState("OrderBy")]String OrderBy = null)
    {
        var list = GETSOMEOBJECTS();
        if (OrderBy != null)
        {
            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    list = list.OrderByDescending(OrderBy);
                    break;
                case SortDirection.Descending:
                    list = list.OrderBy(OrderBy);
                    break;
                default:
                    list = list.OrderByDescending(OrderBy);
                    break;
            }
        }
        return fl;
    }
