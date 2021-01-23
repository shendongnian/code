    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using(var transaction = connection.BeginTransaction())
        {
            try
            {
                sessionID = GetSessionIDForAssociate(connection, empID, transaction);
                //Other Code
                transaction.Commit();
             }
             catch
             {
                transaction.Rollback();
                throw;
             }
        }
    }
