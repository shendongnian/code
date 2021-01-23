    DataColumn dynColumn = new DataColumn();
    
    {
        dynColumn.ColumnName = "FullName";
        dynColumn.DataType = System.Type.GetType("System.String");
        dynColumn.Expression = "LastName+' '-ABC";
    }
    UserDataSet.Tables(0).Columns.Add(dynColumn);
