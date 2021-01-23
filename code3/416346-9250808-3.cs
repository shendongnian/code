    // call your stored proc some way...
    using(SqlConnection conn = new SqlConnection("server=.;database=Test;Integrated Security=SSPI;"))
    using (SqlCommand cmd = new SqlCommand("dbo.YourStoredProcNameHere", conn))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        // possibly add parameters to the stored procedure call....
        try
        {
           conn.Open();
           cmd.ExecuteNonQuery();
           conn.Close();
        }
        catch (SqlException ex)
        {  
           // catch SqlException - ex.ErrorNumber contains your error number
           string msg = string.Format("Error number: {0} / Message: {1}", ex.Number, ex.Message);
        }
    }
