    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        SqlTransaction transaction = null;
        try
        {
            transaction = connection.BeginTransaction();
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
                // No need to dispose here - finally is always called
                transaction.Rollback();
            }
            //Throw exception
            throw;
        }
        finally
        {
            if (transaction != null)
            {
                // Always called, so no need to dispose elsewhere.
                transaction.Dispose();
            }
        }
