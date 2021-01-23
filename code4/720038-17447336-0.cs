    // saveLocation is file location
    // numColumns comes from another method that gets number of columns in file
    var columnNames = GetColumnNames(saveLocation, numColumns);
    var table = new DataTable();
    foreach (var header in columnNames)
    {
        table.Columns.Add(header);
    }
    
    // itemAttributeData is the file split into lines
    foreach (var row in itemAttributeData)
    {
        table.Rows.Add(row);
    }
