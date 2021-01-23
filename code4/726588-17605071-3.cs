        public static void DbEdit(string table, string[] columnNames, string[] datatoadd, string whereclause)
    {
        //string[] strColumnNames = { "Activate" };
        //string[] strData = { "Activated" };
        //Database.DbEdit("tblName", strColumnNames, strData, "id='" + activationresponse + "'");
        SqlConnection sqlConn = new SqlConnection();
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.CommandType = CommandType.Text;
        sqlConn.ConnectionString = ConnectionString("test");
        string tblValues = "";
        string tblValuesCN = "";
        for (int i = 0; i < datatoadd.Length; i++)
        {
            sqlCmd.Parameters.Add(new SqlParameter("@" + i.ToString(), datatoadd[i].ToString()));
            tblValues = "@" + i.ToString();
            if (i != datatoadd.Length - 1)
            {
             
            }
       
            if (columnNames[i].ToString() != "")
            {
                tblValuesCN = tblValuesCN + columnNames[i].ToString() + "=" + tblValues + ",";
            }
          
        }
        tblValuesCN = tblValuesCN.Remove(tblValuesCN.Length - 1, 1);
        sqlCmd.CommandTimeout = 0;
        if (whereclause != "")
        {
            sqlCmd.CommandText = "Update " + table + " Set " + tblValuesCN + " where " + whereclause;
        }
        else
        {
            sqlCmd.CommandText = "Update " + table + " Set " + tblValuesCN;
        }
        sqlConn.Open();
        sqlCmd.Connection = sqlConn;
        sqlCmd.ExecuteNonQuery();
        sqlConn.Close();
        sqlCmd.Dispose();
    }
