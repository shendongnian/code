    Debug.WriteLine(dt.TableName);
    foreach(DataColumn column in dt.Columns)
    {
        Debug.WriteLine("\t" + column.ColumnName);
    }
