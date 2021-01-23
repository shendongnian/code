    try
    {
       DataAccess.clsConnection clsDB = new DataAccess.clsConnection();
       using(SqlConnection cn = clsDB.OpenCon())
       {
           SqlCommand cmd = new SqlCommand();
           cmd = CreateCommand(sql, type, paramList);
           cmd.Connection = cn;
           cmd.CommandType = type;
           cmd.CommandText = sql;
           cmd.ExecuteNonQuery();
        // Here the closing braces closes and disposes the connection freeing the resources used
        // also in case of exceptions 
        }  
    }
    catch (Exception ex)
    {
        ....
    }
