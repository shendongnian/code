            var connection =  new SqlConnection("connectionString");
            try
            {
                connection.Open();
                ....
            }
            finally
            {
                connection.Close();
            }
