    OleDbConnection con = new OleDbConnection(cntStr);
    con.Open();
    OleDbCommand cmd = new OleDbCommand("F_TESTFUNC", con); 
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.Add(new OleDbParameter("retVal", OleDbType.VarChar, 11,ParameterDirection.ReturnValue, true, 0, 0, "retVal", DataRowVersion.Current,null);
    cmd.Parameters.Add("ID", strID);
    cmd.ExecuteScalar();
    con.Close();
