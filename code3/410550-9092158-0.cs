    public   DataTable   GetTable(IDataReader   _reader) 
    { 
    DataTable   dataTable1   =   _reader.GetSchemaTable(); 
    DataTable   dataTable2   =   new   DataTable(); 
    string[]   arrayList   =   new   string[dataTable1.Rows.Count]; 
    for   (int   i   =   0;   i   <   dataTable1.Rows.Count;   i++) 
    { 
    DataColumn   dataColumn   =   new   DataColumn(); 
    if   (!dataTable2.Columns.Contains(dataTable1.Rows[i][ "ColumnName "].ToString())) 
    { 
    dataColumn.ColumnName   =   dataTable1.Rows[i][ "ColumnName "].ToString(); 
    dataColumn.Unique   =   Convert.ToBoolean(dataTable1.Rows[i][ "IsUnique "]); 
    dataColumn.AllowDBNull   =   Convert.ToBoolean(dataTable1.Rows[i][ "AllowDBNull "]); 
    dataColumn.ReadOnly   =   Convert.ToBoolean(dataTable1.Rows[i][ "IsReadOnly "]); 
    dataColumn.DataType   =   (Type)dataTable1.Rows[i][ "DataType "]; 
    arrayList[i]   =dataColumn.ColumnName; 
    dataTable2.Columns.Add(dataColumn); 
    } 
    } 
    dataTable2.BeginLoadData(); 
    while   (_reader.Read()) 
    { 
    DataRow   dataRow   =   dataTable2.NewRow(); 
    for   (int   j   =   0;   j   <   arrayList.Length   ;   j++) 
    { 
    dataRow[arrayList[j]]   =   _reader[arrayList[j]]; 
    } 
    dataTable2.Rows.Add(dataRow); 
    } 
    _reader.Close(); 
    dataTable2.EndLoadData(); 
    return   dataTable2; 
    } 
