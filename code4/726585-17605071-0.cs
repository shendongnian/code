        public static void DbInsert(string table, string[] columnNames, string[] datatoadd)
    {
        //string table name, column names to be updated, data as string in array
        //string[] strColumnNames = { "test1", "test2", "test3", "test4" };
        //string[] strValues = { "value1", "value2", "value3", "value4" };
        //Database.DbInsert("tblName", valscn, vals);
        SqlConnection sqlConn = new SqlConnection();
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.CommandType = CommandType.Text;
        
        sqlConn.ConnectionString = ConnectionString("LiveConnection");
        string tblValues = "";
        string tblValuesCN = "";
        for (int i = 0; i < datatoadd.Length; i++)
        {
            sqlCmd.Parameters.Add(new SqlParameter("@" + i.ToString(), datatoadd[i].ToString()));
            tblValues = tblValues + "@" + i.ToString();
            if (i != datatoadd.Length-1)
            {
                tblValues = tblValues + ",";
            }
        }
        for (int i = 0; i < columnNames.Length; i++)
        {
            tblValuesCN = tblValuesCN + columnNames[i].ToString();
            if (i != columnNames.Length - 1)
            {
                tblValuesCN = tblValuesCN + ",";
            }
        }
        sqlCmd.CommandTimeout = 0;
        sqlCmd.CommandText = "Insert Into " + table + "(" + tblValuesCN + ") Values (" + tblValues + ")";
        
        sqlConn.Open();
        sqlCmd.Connection = sqlConn;
        sqlCmd.ExecuteNonQuery();
        sqlConn.Close();
        sqlCmd.Dispose();
    }
