    ....
    using(OleDbConnection oleConn = new OleDbConnection(connString))
    {
        try
        {
            oleConn.Open();
            string sql = "SELECT * FROM [Customer] WHERE [Customer's Ebayname]=@cust";
            OleDbCommand cmd = new OleDbCommand(sql, oleConn);
            cmd.Parameters.AddWithValue("@cust", custName);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            dataAdapter.Fill(dataSet, "Customer");
        }
    }
    ....
