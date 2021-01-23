            string connection = @"Data Source=.\SQLExpress;" +
                                 "User Instance=true;" +
                                 "Integrated Security=true;" +
                                 "AttachDbFilename=|DataDirectory|GCdatabase.mdf;";
            string insertSql = "INSERT INTO Table " +
                              "(Column1, Column2) VALUES " +
                              "(@Column2, @Column2); SELECT @@identity;";
            using (SqlConnection connection =
                   new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertSql;
                command.Parameters.Add(new SqlParameter("@Column1", Column1));
                command.Parameters.Add(new SqlParameter("@Column2", Column2));
                
                connection.Open();
                command.ExecuteNonQuery();
            } 
