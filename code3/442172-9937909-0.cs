    var records = (from item in this.GetData().Cast<IContent>()
                               select new
                               {
                                   Title = "1",
                                   Street = "2",
                                   City = "3",
                                   Country = "4"
                               });
    var firstRecord = records.First();
    if (firstRecord == null)
        return;
    PropertyInfo[] infos = firstRecord.GetType().GetProperties();
    DataTable table = new DataTable();
    foreach (var info in infos)
    {
        DataColumn column = new DataColumn();
        column.Caption = info.Name;
        column.DataType = info.PropertyType;
        table.Columns.Add(column);
    }
    foreach (var record in records)
    {
        DataRow row = table.NewRow();
        for (int i = 0; i < table.Columns.Count; i++)
            row[i] = infos[i].GetValue(record);
    }
