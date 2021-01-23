    using (SQLiteConnection con = new SQLiteConnection { ConnectionString = "connectionstring" })
    {
         using(SQLiteCommand cmd = new SQLiteCommand { Connection = con })
         {
             // check connection state if open then close, else close proceed
             if(con.State == ConnectionState.Open)
               con.Close();
    
             //then
             try
             {
                // try connection to Open
                con.Open();
             }
             catch
             {
                // catch connection error.
             }
    
             try
             {
                 // your insert query
             }
             catch
             {
                 // catch query error
             }
    
         } // Close Command
    
    }  // Close Connection
 
