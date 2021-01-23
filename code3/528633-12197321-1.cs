    public void FillGridView(string Table, Control GridView) 
    {
        var property = typeof(InformitoDataContext).GetProperty(Table);
        IQueryable query = (IQueryable)(property.GetGetMethod().Invoke(db, new object[0]));
        (GridView as GridView).DataSource = query;
        (GridView as GridView).DataBind();
    }
