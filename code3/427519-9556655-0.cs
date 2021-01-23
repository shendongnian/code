     // Given command text and connection string, asynchronously execute
        // the specified command against the connection. For this example,
        // the code displays an indicator as it is working, verifying the 
        // asynchronous behavior. 
        using (SqlConnection connection = 
                   new SqlConnection(connectionString))
        {
            try
            {
                int count = 0;
                SqlCommand command = new SqlCommand(commandText, connection);
                connection.Open();
                IAsyncResult result = command.BeginExecuteNonQuery();
                while (!result.IsCompleted)
                {
                    Console.WriteLine("Waiting ({0})", count++);
                    // Wait for 1/10 second, so the counter
                    // does not consume all available resources 
                    // on the main thread.
                    System.Threading.Thread.Sleep(100);
                }
                Console.WriteLine("Command complete. Affected {0} rows.", 
                    command.EndExecuteNonQuery(result));
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error ({0}): {1}", ex.Number, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                // You might want to pass these errors
                // back out to the caller.
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }
