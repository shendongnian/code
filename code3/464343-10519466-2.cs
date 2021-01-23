    using (DBConnection conn = new ...)
    {
        using (DbCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = commandText;
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                foreach (DbDataRecord record in reader) { yield return record; }
            }
        }
    }
