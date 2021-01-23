    using (DbConnection connection =
        new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
        using (DbCommand command = connection.CreateCommand())
        {
            DbTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                command.CommandText = "The SQL to validate";
                command.ExecuteNonQuery();
                //The SQL is valid
            }
            catch
            {
                // The SQL is not valid
            }
            finally
            {
                transaction.Rollback();
            }
        }
    }
