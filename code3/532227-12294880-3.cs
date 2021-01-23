    for (int rowIndex = 0; rowIndex < schema.Rows.Count; rowIndex ++)
    {
        DataRow schemaRow = schema.Rows[rowIndex];
        String columnName = schemaRow.Field<String>("ColumnName");
        Type dataType = schemaRow.Field<Type>("DataType");
        Int32 columnSize = schemaRow.Field<Int32>("ColumnSize");
        if (dataType.FullName == "System.String")
        {
            // ...
        } 
     }
