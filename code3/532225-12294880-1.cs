    for (int rowIndex = 0; rowIndex < schema.Rows.Count; rowIndex ++)
    {
        DataRow schemaRow = schema.Rows[rowIndex];
        Type dataType = schemaRow.Field<Type>("DataType");
        int columnSize = schemaRow.Field<int>("ColumnSize");
        if (dataType.FullName == "System.String")
        {
            // ...
        } 
     }
