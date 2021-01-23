    //assuming Table1 has a single INT column, Column1 and has one row with value 12345
    //and connectionstring contains a valid connection string to the database.
        //this automatically starts a transaction for you
    try
    {
                using (TransactionScope ts = new TransactionScope())
                {
            //you can open as many connections as you like within the scope although they need to be on the same server. And the transaction scope goes out of scope if control leaves this code.
                   using (SqlConnection conn = new SqlConnection(connectionstring))
                   {
                      conn.Open();
                      using (SqlCommand comm = new SqlCommand("Insert into Table1(Column1) values(999)")
                      {
                        comm.ExecuteNonQuery();
                      }
                       using (SqlCommand comm1 = new SqlCommand("DELETE from Table1 where Column1=12345"))
                       {
                         comm1.ExecuteNonQuery();
                       }
                    }//end using conn
                   ts.Complete() ; //commit the transaction; Table1 now has 2 rows (12345 and 999) 
                }//end using ts
                 
    }
      catch(Exception ex)
       {
         //Transaction is automatically rolled back for you at this point, Table1 retains original row.
       }
