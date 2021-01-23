    using (Conn = new OleDbConnection(Work_Connect))
    {
        Conn.Open();
        foreach (DataRow R in ds.Tables["MyCount"].Rows)
        {
            U_ID = ID;
            U_Bar = R["Bar"].ToString().Trim();
            U_Qty = R["Qty"].ToString().Trim();
            U_Des = R["Des"].ToString().Trim();
    
            SQL  = "INSERT INTO MyTbl (ID,Bar,Qty,Des) VALUES (?,?,?,?)";
            using(OleDbCommand Cmd2 = new OleDbCommand(SQL, Conn))
            {
                // Cmd2.CommandText = SQL;  redundant, the 'new' set the .CommandText
                Cmd2.Parameters.AddWithValue("?", Convert.ToInt32(ID));
                Cmd2.Parameters.AddWithValue("?", U_Bar);
                Cmd2.Parameters.AddWithValue("?", Convert.ToDouble(U_Qty));
                Cmd2.Parameters.AddWithValue("?", U_Des);
                Cmd2.ExecuteNonQuery();
            }
        }
        Conn.Close();
    }
    // GC.Collect();  // disabled for test purposes
    return true;
