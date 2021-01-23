        SqlCommand command = new SqlCommand(selectCmd, conn);
        SqlDataReader reader = command.ExecuteReader();
        try
        {
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}, {1}",
                    reader[0], reader[1]));
            }
        }
        finally
        {
            // Always call Close when done reading.
            reader.Close();
        }
