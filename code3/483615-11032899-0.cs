    SqlParameter n = new SqlParameter();
    n.ParameterName = "@N0";
    n.SqlDbType = SqlDbType.Int;
    n.Direction = ParameterDirection.Output;
    getData.Parameters.Add(n); 
