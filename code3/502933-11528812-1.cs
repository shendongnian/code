    protected void LinqDataSource_Selected(object sender, LinqDataSourceStatusEventArgs e)  // event fires after data retrieval complete.
    {
        List<int> ids = new List<int>();
        if (e.TotalRowCount > 0)
        {
            foreach(Foo foo in (IEnumerable)e.Result)
            {
                ids.Add(foo.Id);
            }
        }
    }
