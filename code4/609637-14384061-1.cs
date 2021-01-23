    //try
    //{
        sqlComm.Connection.Open();
        sqlComm.ExecuteNonQuery();
        return Convert.ToInt64(sqlComm.Parameters["@AddressID"].Value);
        // using Int64 since the SQL type is BigInt
    //}
    
    //catch (SqlException)
    //{
    //}
    
    //finally
    //{
    //    sqlComm.Connection.Close();
    //}
