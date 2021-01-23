    string newRequestID = "";
    using (SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["dbString"].ConnectionString))
    {
        using (SqlCommand command = new SqlCommand("dbo.sp_generateNewRequestId", connection))
        {
            command.Parameters.AddWithValue("@Customer", customer);
            command.Parameters.AddWithValue("@Network_Type", technology);
            command.Parameters.AddWithValue("@Market_Name", market);
            command.Parameters.Add("@NewRequestId", SqlDbType.VarChar).Direction = ParameterDirection.Output;
            command.Parameters["@NewRequestId"].Size = 50;
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            command.ExecuteNonQuery();
            newRequestID = (string)command.Parameters["@NewRequestId"].Value;
            connection.Close();
         }
    }
