    using (SqlCommand sqlComm = new SqlCommand(strSql, DataConn.Connect()) { CommandType = CommandType.Text })
    {
        SqlDataAdapter da = new SqlDataAdapter(sqlComm);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ds.Tables[0].WriteXml(@"C:\Temp\text.xml");
    }
