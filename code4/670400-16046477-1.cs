            var connection = new SqlConnection("Data Source=xxx;Initial Catalog=Test;User Id=xxx;Password=xxx");
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "TestError";
                command.Parameters.AddWithValue("@ThrowDivideError", 1);
                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                reader.Read();
                reader.NextResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
