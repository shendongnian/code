    //The connection string to the excel file
    string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _fileUrl + ";Extended Properties=Excel 12.0;";
    //The query
    string strSQL = "SELECT * FROM [Sheet1$]";
    //The connection to that file
    using(OleDbConnection conn = new OleDbConnection(connstr))
    using(OleDbCommand cmd = new OleDbCommand(strSQL, conn))
    {
        conn.Open();
        DataTable dt = new DataTable();
        try
        {
            using(OleDbDataReader dr1 = cmd.ExecuteReader())
            {
                dt.Load(dr1);
            }
            string result = Path.GetFileNameWithoutExtension(_fileName);
            string outFile = Path.Combine(@"C:\Users\Administrator\Desktop\GBOC\Activation\Destination", result + ".txt");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dt.Columns.Count - 1; i++)
                sb.AppendFormat("'{0}',", dt.Columns[i].ColumnName);
            sb.Length--;
            sb.AppendLine();
            foreach(DataRow r in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count - 1; i++)
                    sb.AppendFormat("'{0}',", r[i].ToString());
                sb.Length--;
                sb.AppendLine();
            }
            using(StreamWriter sw = new StreamWriter(outFile))
                sw.Write(sb.ToString());
         }
         catch(Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
    }         
