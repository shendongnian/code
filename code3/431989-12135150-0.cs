    Equals, with Oracle.DataAccess.dll    Works!!!!
    //using Oracle.DataAccess.Client
    
    object pdf = null;
            
    var queryString =@"SELECT PDF  FROM DIGITAL  WHERE ID_DIGITAL=1001" ;  //example
    var ctx = new Entities();
    var entityConn = ctx.Connection as EntityConnection;
    
    if (entityConn != null)
    {
    var dbConn = entityConn.StoreConnection as OracleConnection;
    dbConn.Open();
    
    var cmd = new OracleCommand(queryString, dbConn);
    using (var reader = cmd.ExecuteReader())
    {
    while (reader.Read())
    {
    pdf = reader[0];
    }
    }
    dbConn.Close();
    }
    return pdf;
