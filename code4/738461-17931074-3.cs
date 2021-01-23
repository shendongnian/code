    SqlParameter parameter = new SqlParameter();
    parameter.ParameterName = "@RowId";
    parameter.SqlDbType = SqlDbType.Decimal; 
    parameter.Direction = ParameterDirection.Output;
    
    command.Parameters.Add(parameter);
    command.ExecuteNonQuery();
    if (parameter.Value!=DbNull.Value)
    {
       newRowID = (Int32) parameter.Value;
    }
