    IEnumerable<String> lines = File.ReadLines(filePath);
    String header = lines.First();
    var headers = header.Split(new[]{','}, StringSplitOptions.RemoveEmptyEntries);
    DataTable tbl = new DataTable();
    for (int i = 0; i < headers.Length; i++)
    {
        tbl.Columns.Add(headers[i]);
    }
    var data = lines.Skip(1);
    foreach(var line in data)
    {
        var fields = line.Split(new[]{','}, StringSplitOptions.RemoveEmptyEntries);
        DataRow newRow = tbl.Rows.Add();
        newRow.ItemArray = fields;
    }
