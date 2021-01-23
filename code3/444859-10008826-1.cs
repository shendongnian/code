    string commandText = "SP_Your_Sp_Name";
    
    using (SqlConnection objSqlConnection = Connection)
    
    {
    
        using (SqlCommand cmd = new SqlCommand(commandText, objSqlConnection))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Parameter_Name", value));
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            result = (string)cmd.ExecuteScalar();
        }
    }
