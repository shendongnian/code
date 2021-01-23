        private void loadMilk(string tableName)
        {
            cn.Open();
            OleDbDataReader reader = null;
            OleDbCommand cmd = new OleDbCommand(string.Format("select* from {0}",tableName), cn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Milk.Add(reader["Product"].ToString());
            }
            cn.Close();
        }
