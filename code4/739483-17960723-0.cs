    using (SqlConnection saConn = new SqlConnection(this.ConnectionString))
    {
           saConn.Open();
    
           string query = "select DBName from dbo.Company";
           SqlCommand cmd = new SqlCommand(query, saConn);
    
           using (SqlDataReader saReader = cmd.ExecuteReader())
           {
                while (saReader.Read())
                {
                       string name = saReader.GetString(0);
                       combobox1.Add(name);
                 }
            }
            saConn.Close();
    }
