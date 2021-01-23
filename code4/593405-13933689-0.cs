    public string Adscategory(string Name)
    {
    string temp = String.Empty;
    using (SqlConnection conn= new SqlConnection(ConfigurationManager.ConnectionStrings["testconnection"].ToString()))
    {
        conn.Open();
        // INJECTION ALERT: Use the appropriate SqlParameters
        using (SqlCommand comm = new SqlCommand(String.Format("SELECT Id FROM TestTable WHERE tid=@nameParam", Name), conn))
        {
            comm.Parameters.AddWithValue("@nameParam", Name);
            try
            {
                temp = comm.ExecuteScalar().ToString();
            }
            catch(SqlException ex) { /*DB error, react appropriately !*/ }
            // catch(Exception ex) { /*Gotta catch'em all ... don't do this. */ }
        }
        return temp;
    }
