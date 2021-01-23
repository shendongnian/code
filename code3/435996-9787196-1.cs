    using (MySqlConnection connection = new MySqlConnection(...))
    {
        connection.Open();
        using (MySqlCommand cmd = new MySqlCommand("select product_price from product where product_name='@pname';", connection))
        {
            cmd.Parameters.AddWithValue("@pname", x);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                StringBuilder sb = new StringBuilder();
                while (reader.Read())
                    sb.Append(reader.GetInt32(0).ToString());
                Price_label.Content = sb.ToString();
            }
        }
    }
