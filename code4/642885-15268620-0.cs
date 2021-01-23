    void DoStuff(args)
    {
        using (var conn = CreateOpenConnection())
        using (var tran = conn.BeginTransaction())
        {
            try
            {
                // various operations here
                ForExample(conn, tran);
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }
    }
    void ForExample(DbConnection conn, DbTransaction tran = null)
    {
        using (var cmd = conn.CreateCommand())
        {
            cmd.Transaction = tran;
            cmd.CommandText = "For example";
            // cmd.Parameters.Add(...)
            cmd.ExecuteNonQuery();
        }
    }
