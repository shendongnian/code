     var dtCompleteRecords = new DataTable("CompleteRecords");
     table2.Columns.Add(new DataColumn("a", typeof(string)));
     table2.Columns.Add(new DataColumn("b", typeof(string)));
     table2.Columns.Add(new DataColumn("c", typeof(string)));
 
    dtRecords.AsEnumerable()
        .Select(row => row["Token"].ToString().Split('|'))
        .ToList()
        .ForEach(array => dtCompleteRecords.Rows.Add(array));
