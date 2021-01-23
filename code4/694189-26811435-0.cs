    foreach (DataColumn col in table.Columns)
    {
        //Fix column names if the Reader insert the table name into the ColumnName
        col.ColumnName = col.ColumnName.Replace(table_name + ".", "");
    }
