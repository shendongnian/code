    using (SqlConnection oConn = new SqlConnection(ConnectionString)) 
    {     
       using (SqlCommand cmd = new SqlCommand("IC_Expense_InsertCycle", oConn))     
       {
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.AddWithValue("@PortalId", portalId);
          cmd.Parameters.AddWithValue("@Description", description);
          cmd.Parameters.AddWithValue("@StartDate", start);
          cmd.Parameters.AddWithValue("@EndDate", end);          
          try
          {
             oConn.Open();
             cmd.ExecuteNonQuery();
          }
          catch (SqlException ex)
          {
             throw ex;
          }
       }//close the SqlCommand
       //Get the new set of ExpenseCycles for binding
       ExpenseCycle cycle = new ExpenseCycle(ConnectionString);
       return cycle.GetExpenseCycles(portalId);
       //This might fix your problem. 
    } 
