    SqlParameter parameter = new SqlParameter();
    parameter.ParameterName = "@RowId";
    parameter.SqlDbType = SqlDbType.Int;
    parameter.Direction = ParameterDirection.Output;
    
    command.Parameters.Add(parameter);
    command.ExecuteNonQuery();
    
    newRowID = (Int32) parameter.Value;
