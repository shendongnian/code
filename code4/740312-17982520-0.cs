    int catCount = 1;     
    string connectionString = "server=server;user id=user;password=password;database=db;"
    string query = "SELECT email FROM oc_newsletter_old_system WHERE cat_uid=@cat_uid";
    while (catCount < 13)
    {
        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            con.Open();
            MySqlCommand mC = new MySqlCommand(query, con);
            mC.Parameters.AddWithValue("@cat_uid", catCount);
            using (MySqlDataReader Rd = mC.ExecuteReader())
            {
            
                while (Rd.Read())
                {
                     // rest of your code here
                }
            }
        }    
    }
