    using (SqlConnection conn1 = new SqlConnection())
    {
        using (SqlConnection conn2 = new SqlConnection())
        {
            try
            {
                using (var scope = new System.Transactions.TransactionScope())
                {
                    //when opening the connection, its' implicitly enlisted in the transaction scope
                    conn1.Open();
                    SqlCommand command1 = new SqlCommand(cmdText, conn1);
                    //set parameters
                    command1.ExecuteNonQuery();
    
                    conn2.Open();
                    SqlCommand command2 = new SqlCommand(cmdText, conn1);
                    //set parameters
                    command2.ExecuteNonQuery();
    
                    //transaction commit/rolls back if an exception is thrown
                    scope.Complete();
                }
            }
            catch (System.Transactions.TransactionAbortedException ex)
            {
                //handle aborted transaction
            }
            catch (Exception ex)
            {
                //handle other exceptions
            }
        }
    }
