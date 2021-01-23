    List<int> EmerContacts = new List<int>();
    
    using (MySqlConnection dbConnection = new MySqlConnection("connectionstring"))
    {
        using (MySqlCommand dbCommand = new MySqlCommand("select EmerContact_id from [Table];", dbConnection))
        {
            using (MySqlDataReader dbReader = dbCommand.ExecuteReader())
            {
    
                while (dbReader.Read())
                {
                    EmerContacts.Add((int)dbReader[0].ToString());
    
                 }
            }
        }
    }
    
    Session["EmerContacts"] = EmerContacts;
