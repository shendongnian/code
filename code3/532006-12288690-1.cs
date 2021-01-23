    for (int j = 0; j < schema.Rows.Count; j++)
    {
        DataRow schemaRow = schema.Rows[j];
        Type dataType = schemaRow.Field<Type>("DataType");
        int columnSize = schemaRow.Field<int>("ColumnSize");
        if (dataType.FullName == "System.String")
        {
            String value = dr50[j] as String;
            if (value != null)
                value = value.Substring(0, columnSize);
        } 
     }
