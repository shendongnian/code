    SqlConnection conn = new SqlConnection(strConn);
    SqlCommand cmd = new SqlCommand(strQuery, conn);
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
    using (cmd)
    {
        using (conn)
        {
            conn.Open();
            da.InsertCommand = builder.GetInsertCommand();
            da.Update(ds.Tables[0]);  //ERROR :- Update requires a valid InsertCommand when passed DataRow collection with new rows.
            conn.Close();
        }
    }
