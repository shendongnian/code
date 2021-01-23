    var sqlSelect = "Select field1, field2, field3 FROM yourTable"
    var cmd = new SqlCommand(yourConn)
    
    var sqlWhere = new StringBuilder();
    
    If (sCode > 0)
    {
    cmd.Parameters.Add("@SCode", SqlDbType.int).Value = sCode;
    sqlWhere.Append("@SCode AND");
    }
    If (vCode > 0)
    {
    cmd.Parameters.Add("@VCode ", SqlDbType.int).Value = vCode;
    sqlWhere.Append("@VCode AND");
    }
    
    If(eCode > 0)
    {
    cmd.Parameters.Add("@ECode", SqlDbType.int).Value = eCode ;
    sqlWhere.Append("@ECode AND");
    }
    
    if (sqlWhere.length > 0)
    {
     sqlWhere.Insert("WHERE ",0);
    }
    cmd.CommandText = sqlSelect + sqlWhere.ToString();
    
    using(var sr = SqlDataReader = cmd.ExecuteReader())
    {
      //read your fields
    }
