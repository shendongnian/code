    var tbl = new DataTable();
    tbl.Columns.Add("attachment_id",typeof(Int32));
    tbl.Columns.Add("document_id",typeof(Int32));
    tbl.Columns.Add("attachment_type",typeof(Int32));
    tbl.Columns.Add("create_date",typeof(DateTime));
    var rnd = new Random();
    for(int i=0; i < 10; i++)
    {
        tbl.Rows.Add(i, rnd.Next(1, 5), rnd.Next(1, 3), new DateTime(2012, 07, 24, rnd.Next(1, 24), 0, 0));
    }
