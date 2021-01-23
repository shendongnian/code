    int i = 0;
    int MaxCount = 1000;
    while (i < Reader.FieldCount)
    {
        var tbl = new Table(database, tableName, "schema"); 
        for (int j = i; j < MaxCount; j++) 
        {                            
            col = new Column(tbl, Reader.GetName(j), ConvertTypeToDataType(Reader.GetFieldType(j))); 
            col.Nullable = true; 
            tbl.Columns.Add(col);
            i++;                      
        } 
 
        tbl.Create();                        
        BulkCopy(Reader, tableName); 
    }
