    IEnumerable<DataRow> query = from t in newtable.AsEnumerable()
    group t by new { Col1 = t.Field<String>("ID1"), Col2 = t.Field<String>("ID2") } into grp
     select new
    {
    Col1 = grp.Key.ID1,
    Col2 = grp.Key.ID2
    };
    DataTable boundTable = query.CopyToDataTable<DataRow>();
