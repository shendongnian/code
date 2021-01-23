    private void loadObjectsFrom(string tableName, object obj, string column)
            {
                cn.Open();
                OleDbDataReader reader = null;
                OleDbCommand cmd = new OleDbCommand("select* from " + tableName, cn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    obj.Add(reader[column].ToString());
                }
                cn.Close();
            }
