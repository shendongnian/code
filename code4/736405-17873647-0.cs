    string result1;
    string result2;
    
    using (OracleCommand crtCommand = new OracleCommand(query1, conn1))
    {
        result1 = crtCommand.ExecuteScalar().ToString();
    }
    
    using (OracleCommand ctCommand = new OracleCommand("query2", conn1))
    {
        result2 = ctCommand.ExecuteScalar().ToString();
    }
    
    if (result1.Equals(result2))
        MessageBox.Show("They are same");
    else
        MessageBox.Show("They are not same");
