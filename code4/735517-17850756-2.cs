    using (SqlConnection objcon= new SqlConnection(connectionString))
    {
        SqlCommand cmd = new SqlCommand("SELECT [s_langName] from [dbo].[tx_UserLanguages] WHERE [s_ID] = @id", objcon);
        cmd.Parameters.AddWithValue("@id", Class1.EmployeeId);
        connection.Open();
    
        SqlDataReader reader = cmd .ExecuteReader();
    
        string userlanguages = string.Empty;
        while (reader.Read())
        {
            string str = reader.GetString(0);
            userlanguages = String.Join(",", userlanguages);
        }
        reader.Close();
    }
