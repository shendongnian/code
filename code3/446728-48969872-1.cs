    public static long GetTotalChanges(SQLiteConnection m_dbConnection)
            {
                string sql = "SELECT total_changes();";
                using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return (long)reader[0];
                    }
                }
            }
