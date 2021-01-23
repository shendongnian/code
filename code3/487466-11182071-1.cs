    var dt = new DataTable("MyTable");
    dt.Columns.Add("ID");
    dt.Columns.Add("Name");
    dt.Columns.Add("Active");
    
    dt.LoadDataRow(new[] {"ID1", "John", "True"}, true);
    dt.LoadDataRow(new[] {"ID2", "Bill", "False"}, true);
    JsonConvert.SerializeObject(DatatableToDictionary(dt, "ID"));
