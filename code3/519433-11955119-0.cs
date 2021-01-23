        using (var sqlConnection = new SqlConnection(...))
        {
            string sqlQuery = @"SELECT c.Name,c.ID FROM CarsCatalog c where c.ID > " 
                                + lastID.ToString();
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
            if (sqlReader.Read())
            {
                nameTextBlock.Text = sqlReader.GetString(0);
                lastID = sqlReader.GetInt(1);
            }
        }
