    try
    {
       sqlConnection = new SqlConnection(dbConnectionString);
       SqlCommand command = new SqlCommand("inv_check", sqlConnection);
       command.CommandType = CommandType.StoredProcedure;
       command.Parameters.Add("@batch_date", SqlDbType.DateTime).Value = DateTime.Now; // or the variable which holds datetime
       sqlConnection.Open();
       return command.ExecuteNonQuery();
       sqlConnection.Close();
    }
    catch (SqlException ex)
    {
       Response.Write("SQL Error" + ex.Message.ToString());
    }
