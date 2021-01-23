    string ConnString = ConfigurationManager.AppSettings["AssociatedBank2011ConnectionString"];
    using (SqlConnection conn = new SqlConnection(ConnString))
    using (SqlCommand cmd = new SqlCommand("uspInsertPersonalAccountApplcation", conn))
    {
        cmd.Commandtype = CommandType.StoreProcedure;
        cmd.Parameters.AddWithValue("@AccountType", AcctType);
        cmd.Parameters.AddWithValue("@AccountSubType", AcctSubType);
        cmd.Parameters.AddWithValue("@CheckingOption", CheckOption);
    
        conn.Open();
        cmd.ExecuteNonQuery();
    }
