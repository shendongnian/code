    //Retrieve column schema into a DataTable.
    schemaTable = reader.GetSchemaTable();
    
    int index = schemaTable.Columns.IndexOf("ColumnName");
    DataColumn columnName = schemaTable.Columns[index];
    
    //For each field in the table...
    foreach (DataRow myField in schemaTable.Rows)
      {
        String columnNameValue = myField[columnName].ToString();
        Console.WriteLine("ColumnName " + columnNameValue);
      }
       
