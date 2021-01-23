    List<String> columnData = new List<String>();
    using(SqlConnection connection = new SqlConnection("conn_string"))
    {
        connection.Open();
        string query = "SELECT Column1 FROM Table1";
        using(SqlCommand command = new SqlCommand(query, connection))
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    columnData.Add(reader.GetString(0));
                }         
            }
        }
    }
