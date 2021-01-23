    [EnableQuery(PageSize=1000)]
    public IQueryable<MyDataTable> GetOneThousandRecords()
    {
        return Query()
    }
