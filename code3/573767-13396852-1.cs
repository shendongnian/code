    using (var connection = new SqlCeConnection())
    using (var command = new SqlCeCommand())
    using (var transaction = conn.BeginTransaction())
    {
        command.Transaction = transaction;
        command.ExecuteNonQuery();
        transaction.Commit();
    }
