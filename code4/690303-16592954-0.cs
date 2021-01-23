    using (SqlCommand command = new SqlCommand("INSERT INTO compare1 (acct, itemcode) VALUES (@AcctNum, @ItemCode)", connection))
    {
        // Add new SqlParameter to the command.
         command.Parameters.Add(new SqlParameter("AcctNum", acctNum));
         command.Parameters.Add(new SqlParameter("ItemCode", itemCode));
