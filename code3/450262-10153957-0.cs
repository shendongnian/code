    using(AdsConnection com = new AdsConnection(connectionString));
    {
        conn.Open();
        using(AdsDataAdapter da = new AdsDataAdapter("Select * from Test", conn))
        {
            AdsCommandBuilder cb = new AdsCommandBuilder(da); 
            DataSet ds = new DataSet(); 
            da.Fill(ds, "Test"); 
    
            // Now the connection is still open and you can issue other commands
     
           DataRow newrow = ds.Tables["Test"].NewRow(); 
           newrow["Name"] = "How about"; 
           ds.Tables["Test"].Rows.Add(newrow); 
           
           // da.Update should work here. No more connection closed.
           da.Update(ds, "Test"); 
        }
    } // Exiting from the using block, the connection will be closed
