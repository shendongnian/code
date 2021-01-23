    protected void LinqDataSource_Selected(object sender, LinqDataSourceStatusEventArgs e)  // event fires after data retrieval complete.
    {
        List<int> ids = new List<int>();
        if (e.TotalRowCount > 0)
        {
            List<Foo> fooList = ((IEnumerable)e.Result).ToList();
            for (int idx = 0; idx < fooList.Count; idx++)
            {
                Foo foo = fooList[idx];
                ids.Add(foo.Id);
            }
        }
    }
