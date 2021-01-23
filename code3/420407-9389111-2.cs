    OleDbCommand.Parameters.Add("@ExpenseID", OleDbType.BigInt).Value = Convert.ToInt64(oInputExpense.ExpenseID);
    OleDbCommand.Parameters.Add("@ExpenseName", OleDbType.VarChar).Value = Convert.ToString(oInputExpense.ExpenseName);
    OleDbCommand.Parameters.Add("@SAPCode", OleDbType.VarChar).Value = Convert.ToString(oInputExpense.SAPCode);
    OleDbCommand.Parameters.Add("@MaxLimit", OleDbType.Decimal, 2).Value = Convert.ToDecimal(oInputExpense.MaxLimit);
    OleDbCommand.Parameters.Add("@ExpenseType", OleDbType.VarChar).Value = Convert.ToString(oInputExpense.ExpenseType);
    
    //OleDbCommand.Parameters.AddWithValue("@ExpenseID", Convert.ToInt64(oInputExpense.ExpenseID.ToString()));
    //OleDbCommand.Parameters.AddWithValue("@ExpenseName", oInputExpense.ExpenseName.ToString());
    //OleDbCommand.Parameters.AddWithValue("@SAPCode", oInputExpense.SAPCode.ToString());
    //OleDbCommand.Parameters.AddWithValue("@MaxLimit", Convert.ToDecimal(oInputExpense.MaxLimit));
    //OleDbCommand.Parameters.AddWithValue("@ExpenseType", oInputExpense.ExpenseType.ToString());
