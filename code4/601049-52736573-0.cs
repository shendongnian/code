     List<SqlDataRecord> dataTable = new List<SqlDataRecord>();
    var dr = new SqlDataRecord(
                                new SqlMetaData("Id", SqlDbType.Int),
                                new SqlMetaData("Value", SqlDbType.Variant));
    							
    dr.SetInt32(0, id);
    dr.SetValue(4, myObject);
    
    dataTable.Add(dr);
    
    [...]
    
    SqlCommand sqlCommand = new SqlCommand("dbo.MyProc");
    var structuredParam = sqlCommand.Parameters.Add("myTableParam", SqlDbType.Structured);
    structuredParam.Value = dataTable;
