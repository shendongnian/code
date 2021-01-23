    var connectionstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    
    var addressId = 0L; // long value (64bit)
    using (var connection = new SqlConnection(connectionString))
    using (var command = new SqlCommand("up_Insert_Address", connection))
    {
      command.CommandType = CommandType.StoredProcedure;
      command.Parameters.AddWithValue("@AddressID", addressId);    
      command.Parameters.AddWithValue("@AddressLineOne", address.AddressLineOne); 
      command.Parameters["@AddressID"].Direction = ParameterDirection.Output;
      try
      {
        if(connection.State != ConnectionState.Open)
          connection.Open();
        var rowsAffected = command.ExecuteNonQuery();
        var result = command.Parameters["@AddressID"].Value.ToString();
        if(!long.TryParse(result, out addressId))
        {
          // Handle long integer parsing errors here.
        }
      }
      catch (SqlException)
      {
        // Handle SQL errors here.
      }
    }
