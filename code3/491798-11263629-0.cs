    public int InsertDataTable(DataTable dt, string selectCommand)
        {
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(selectCommand, m_conn);
            SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapter);
            SQLiteTransaction transaction = m_conn.BeginTransaction();
            builder.GetInsertCommand().Transaction = transaction;
            int rowsAffected = adapter.Update(dt.Select());
            transaction.Commit();            
            return rowsAffected;
        }
