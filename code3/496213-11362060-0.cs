    var t1Cols = table1.Columns.Cast<DataColumn>();
    var t2Cols = table2.Columns.Cast<DataColumn>();
  
    var diffTypes =  
        from t1Col in t1Cols
        join t2Col in t2Cols on t1Col.ColumnName equals t2Col.ColumnName
        where t1Col.DataType != t2Col.DataType
        select string.Format("{0}<{1}>,{2}<{3}>",
            t1Col.ColumnName, t1Col.DataType, t2Col.ColumnName, t2Col.DataType);
    var diffMaxLength = 
        from t1Col in t1Cols
        join t2Col in t2Cols on t1Col.ColumnName equals t2Col.ColumnName
        where t1Col.MaxLength != t2Col.MaxLength
        select string.Format("{0}<{1}>,{2}<{3}>",
            t1Col.ColumnName, t1Col.MaxLength, t2Col.ColumnName, t2Col.MaxLength);
    Console.WriteLine("diff. Types: " + string.Join(", ", diffTypes));
    Console.WriteLine("diff. max Length: " + string.Join(", ", diffMaxLength));
