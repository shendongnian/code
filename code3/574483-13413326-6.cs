    private static DataTable CreateTableFrom(XElement report)
    {
        DataTable table = new DataTable(report.Name.LocalName);
        table.Columns.AddRange(GetColumnsOf(report));
    
        foreach (var row in report.Descendants("Row"))
        {
            DataRow dr = table.NewRow();
            foreach (var field in row.Elements())
                dr[field.Name.LocalName] = (string)field;
            table.Rows.Add(dr);
        }
    
        return table;
    }
    
    private static DataColumn[] GetColumnsOf(XElement report)
    {
        return report.Descendants("Row")
                     .SelectMany(row => row.Elements().Select(e => e.Name.LocalName))
                     .Distinct()
                     .Select(field => new DataColumn(field))
                     .ToArray();
    }
