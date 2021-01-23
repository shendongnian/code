        public bool isDataExists(string sql)
        {
            try
            {
                OpenConnection();
                SQLiteCommand cmd = new SQLiteCommand(sql, connection);
                reader = cmd.ExecuteReader();
                if (reader != null && reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception expMsg)
            {
                //Exception
            }
            finally
            {
                if (reader != null)
                {
                    reader.Dispose();
                }
                CloseConnection();
            }
            return true;
        }
