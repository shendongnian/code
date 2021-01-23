    public static DataTable InnerJoin(DataTable dt1, DataTable dt2, DataColumn Parent, DataColumn Child)
    {
        DataTable result = new DataTable();
        result.Columns.Add("Row1", typeof(DataRow));
        result.Columns.Add("Row2", typeof(DataRow));
        var query =
            from row1 in dt1.AsEnumerable()
            join row2 in dt2.AsEnumerable() on row1[Parent] equals row2[Child]
            select new { row1, row2 };
       
        foreach (var x in query)
        {
            result.Rows.Add(x.row1, x.row2);
        }
        return result;
    }
