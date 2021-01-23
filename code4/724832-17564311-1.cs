    DataTable table = new DataTable();
    table.Columns.Add("LossDate", typeof(string));
    table.Rows.Add(new DateTime(2004, 05, 27));
    table.Rows.Add(DBNull.Value);
    table.Rows.Add("A90317");
    table.Rows.Add(new DateTime(2009, 06, 27));
    table.Rows.Add("A90118");
    table.Rows.Add(DBNull.Value);
    table.Rows.Add("A00921");
    table.Rows.Add(DBNull.Value);
    table.Rows.Add(new DateTime(2005, 06, 27));
    DateTime dt;
    var temp = table.AsEnumerable()
     .OrderBy(x => x.Field<string>("LossDate") !=null)
    	.ThenByDescending(p => !DateTime.TryParse(p.Field<string>("LossDate"), out dt))
    	.ThenBy(x => x.Field<string>("LossDate"));
    var result =temp.AsDataView().ToTable();
