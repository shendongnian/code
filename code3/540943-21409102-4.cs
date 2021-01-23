                OpenConnection();
                SQLiteCommand cmd = new SQLiteCommand(sql, connection);
                reader = cmd.ExecuteReader();
                if (reader != null && reader.Read())
                {
                    cmd.Dispose();
                    CloseConnection();
                    return true;
                }
                else
                {
                    cmd.Dispose();
                    CloseConnection();
                    return false;
                }
