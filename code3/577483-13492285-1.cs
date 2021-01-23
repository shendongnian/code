    DataTable table = new DataTable();
    table.Columns.Add("Years");
    table.Columns.Add("RSF");
    foreach(var item in query)
    {
         table.Add(item.Years, items.RSF)
    }
