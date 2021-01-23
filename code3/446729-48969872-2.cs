    public static long MyBulkInserts()
            {
                using (SQLiteConnection m_dbConnection = new SQLiteConnection())
                {
                    m_dbConnection.Open();
                    using (var cmd = new SQLiteCommand(m_dbConnection))
                    {
                        using (var transaction = m_dbConnection.BeginTransaction())
                        {
                            //loop of bulk inserts
                            {
                                cmd.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                    }
                    return GetTotalChanges(m_dbConnection);
                }
            }
