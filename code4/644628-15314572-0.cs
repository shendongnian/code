    OleDbCommand command = new OleDbCommand();
    command.CommandText = queryString;
    command.Connection = myCon;
    myCon.Open();
    OleDbDataReader dr = command.ExecuteReader();
    while(dr.Read())
    {
       StudIDTb.Text += dr["StudID"].ToString();
       StudNameTb.Text += dr["StudName"].ToString();
       StudCNCITb.Text += dr["StudCNCI"].ToString();
       StudDOBTb.Text += dr["StudDOB"].ToString();
    }
    myCon.Close();
