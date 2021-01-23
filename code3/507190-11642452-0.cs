     using (SqlConnection conn = new SqlConnection("Data Source=19-20\\sqlexpress;" + "Initial Catalog = mpsip; Integrated Security = SSPI"))
     {     
        conn.Open();
        SqlCommand cmdDel = conn.CreateCommand();
        SqlTransaction transaction = conn.BeginTransaction("MyTransaction");
        cmdDel.Connection = conn;
        cmdDel.Transaction = transaction;
        try {
            for (int i = 0; i < Repeater1.Items.Count; i++)
            { 
             cmdDel.CommandText = "delete from messages where messageID = '" + ((Messages)Repeater1.Items[i].DataItem).messageID + "'";
             cmdDel.ExecuteNonQuery();
        
             // Continue your code here
        
             }
             transaction.Commit();
        }
        catch(Exception e) {
            transaction.RollBack();
        }
    }
