    using (MySqlConnection dbConnection = new MySqlConnection("connectionstring"))
    {
        using (MySqlCommand dbCommand = new MySqlCommand("select EmerContact_id from [Table];", dbConnection))
        {
            using (MySqlDataReader dbReader = dbCommand.ExecuteReader())
            {
                int index = 1;
                while (dbReader.Read())
                {
                    Session["Emer" + index.ToString()] = dbReader[0].ToString();
                    index++;
                }
            }
        }
    }
