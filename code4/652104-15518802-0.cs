    string fileName = "Activity.xls";
                                savePath += fileName; 
    OleDbConnection conn= new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath(savePath) + ";Extended Properties='Excel 12.0;HDR=YES'");
        if (conn.State == ConnectionState.Closed)
        conn.Open();
        string query = "select * from [Sheet1$]";
          OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                                    DataSet ds = new DataSet();
                                    da.Fill(ds, "Activities");
                                    dt = ds.Tables[0];
                                    conn.Close();
