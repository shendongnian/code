    public const int PAGE_SIZE = 10;
    protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
    // LINQ query
        var query = from m in db.Products
        select m;
        // Set the total count
        // so GridView knows how many pages to create
        e.Arguments.TotalRowCount = query.Count();
        // Get only the rows we need for the page requested
        query = query.Skip(GridView1.PageIndex * PAGE_SIZE).Take(PAGE_SIZE);
        e.Result = query;
    }
