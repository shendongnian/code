    private void loadMilk(string TableName, string itemValue)
            {
                string SQLString = String.Format("select * from {0}",TableName");
    
                cn.Open();
                OleDbDataReader reader = null;
                OleDbCommand cmd = new OleDbCommand(SQLString, cn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Milk.Add(reader[ItemValue].ToString());
                }
                cn.Close();
            }
