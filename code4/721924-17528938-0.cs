            string queryString = "SELECT * FROM DBATABC";
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    OleDbCommand command = new OleDbCommand(queryString, connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                string companyCode = reader.GetString(0).ToString();
                            }
                        }
                    }
                    reader.Close();
                }
            }
