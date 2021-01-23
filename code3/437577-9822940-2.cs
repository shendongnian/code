    // code sample adapted from MSDN
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction("SampleTransaction");
        SqlCommand command = connection.CreateCommand();
        command.Transaction = transaction;
        try
        {
            command.CommandText = "TODO"; // Copy rows from Orders to OrdersXML
            command.ExecuteNonQuery();
            command.CommandText = "TODO"; // Delete copied rows from Orders
            command.ExecuteNonQuery();
            // Attempt to commit the transaction.
            transaction.Commit();
        }
        catch (Exception ex)
        {
            try
            {
                // Attempt to roll back the transaction.
                transaction.Rollback();
            }
            catch (Exception ex2)
            {
                // This catch block will handle any errors that may have occurred
                // on the server that would cause the rollback to fail, such as
                // a closed connection.
            }
        }
