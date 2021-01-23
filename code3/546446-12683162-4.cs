    public static DataTable AsDataTable(XElement root, string tableName, IDictionary<string, Type> typeMapping)
    {
        var table = new DataTable(tableName);
        // set up the schema based on the first row
        XNamespace dt = "urn:schemas-microsoft-com:datatypes";
        var columns =
           (from e in root.Element(tableName).Elements()
            let typeName = (string)e.Element(dt + "dt")
            let type = typeMapping.ContainsKey(typeName ?? "") ? typeMapping[typeName] : typeof(string)
            select new DataColumn(e.Name.LocalName, type)).ToArray();
        table.Columns.AddRange(columns);
        
        // add the rows
        foreach (var rowElement in root.Elements(tableName))
        {
            var row = table.NewRow();
            foreach (var column in columns)
            {
                var colElement = rowElement.Element(column.ColumnName);
                if (colElement != null)
                    row[column.ColumnName] = Convert.ChangeType((string)colElement, column.DataType);
            }
            table.Rows.Add(row);
        }
        return table;
    }
