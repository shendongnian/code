    using (SqlConnection connection = new SqlConnection("connection string here"))
    {
        using (SqlCommand command = new SqlCommand("SELECT Column1 FROM Table1; SELECT Column2 FROM Table2", connection))
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    MessageBox.Show(reader.GetString(0), "Table1.Column1");
                }
     
                if(reader.NextResult())
                {
                   while (reader.Read())
                  {
                    MessageBox.Show(reader.GetString(0), "Table2.Column2");
                  }
                }
            }
        }
    }
