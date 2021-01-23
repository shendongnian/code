    using(SqlConnection conn = new SqlConnection("(add your connection string here)"))
    using(SqlCommand cmd = new SqlCommand("dbo.usp_PettyCash_EditExpenseInfo", conn))
    {
       cmd.CommandType = CommandType.StoredProcedure;
       // add parameters with defined type!
       cmd.Parameters.Add("@ExpenseID", SqlDbType.BigInt).Value = .....;
       cmd.Parameters.Add("@ExpenseName", SqlDbType.VarChar, 100).Value = ".....";
       cmd.Parameters.Add("@SAPCode", SqlDbType.VarChar, 50).Value = ".....";
       cmd.Parameters.Add("@MaxLimit", SqlDbType.Decimal, 15, 2).Value = 100.00;
       cmd.Parameters.Add("@ExpenseType", SqlDbType.VarChar, 50).Value = "......";
       // open connection, call stored procedure, close connection
       conn.Open();
       cmd.ExecuteNonQuery();
       conn.Close();
    }
