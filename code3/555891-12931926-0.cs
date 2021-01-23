    var table = new DataTable();
    using (var parser = new TextFieldParser(File.OpenRead(path)))
    {
        parser.Delimiters = new[]{","};
        parser.HasFieldsEnclosedInQuotes = true;
        ' load DataColumns from first line '
        String[] headers = parser.ReadFields();
        foreach(var h in headers)
                table.Columns.Add(h);
        ' load all other lines as data '
        String[] fields;
        while ((fields = parser.ReadFields()) != null)
        {
            table.Rows.Add().ItemArray = fields;
        }
    }
