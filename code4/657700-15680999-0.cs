        SQLiteConnection m_dbConnection; 
        void createDbAndTable()
        {
            SQLiteConnection.CreateFile("MyDatabase.sqlite");
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite; Version=3;");
            m_dbConnection.Open();
            string sql = "create table myValues (name varchar(20), highScore int)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }
        void fillTable(DataSet ds)
        {
            var dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                var name = dr["name"].ToString();
                var score = Convert.ToInt32(dr["value"].ToString());
                string sql = "insert into myValues (name, highScore) values ( '" + name + "'," + score + ")";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }
            m_dbConnection.Close();
        }
