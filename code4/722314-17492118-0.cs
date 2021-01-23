    using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["key_of_element"]))
    {
        c.Open();
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Table"))
        {
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // do something with the data
            }
        }
    }
