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
             //This assumes data type of messageID is integer, change (int) to the right type
             cmdDel.CommandText = "delete from messages where messageID = '" + ((int)((DataRow)Repeater1.Items[i].DataItem)["messageID"]) + "'";
             cmdDel.ExecuteNonQuery();
        
             // Continue your code here
        
             }
             transaction.Commit();
             //TODO: reload data here and binding to Repeater
        }
        catch(Exception ex) {
            try {
                transaction.Rollback();
            }
            catch(Exception ex1) {
                //TODO: write log
            }
        }
    }
