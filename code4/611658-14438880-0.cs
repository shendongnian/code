    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (SqlTransaction transaction = connection.BeginTransaction())
        {
            try
            {
                sessionID = GetSessionIDForAssociate(connection, empID, transaction);
                //Other code
                //Commit
                transaction.Commit();
            }
            catch
            {
                //Rollback
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                //Throw exception
                throw;
            }
        }
    }
