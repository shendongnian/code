    public void ProcessForm(string[] InputData)
        {
            string ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["AssociatedBankConnectionString"].ToString();
    
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand("uspInsertPersonalAccountApplication", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AccountType", "Savings");
            cmd.Parameters.AddWithValue("@AccountSubType", "Savings");
            cmd.Parameters.AddWithValue("@ExistingCustomer","No");
            cmd.Parameters.AddWithValue("@MiddleInitial",DBNull.Value);
            conn.Open();
            cmd.ExecuteNonQuery();
    
            conn.Close();
        }
