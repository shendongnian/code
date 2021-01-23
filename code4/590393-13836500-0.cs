     private bool isAdmin(string NetID)
    {
    string connString = "Data Source=appSever\\sqlexpress;Initial Catalog=TestDB;Integrated Security=True";
     string cmdText = "SELECT ID, NetID FROM dbo.Admins WHERE NetID = @NetID)";
    using (SqlConnection conn = new SqlConnection(connString))
    {
        conn.Open();
        // Open DB connection.
        using (SqlCommand cmd = new SqlCommand(cmdText, conn))
        {
            cmd.Parameters.AddWithValue("@NetID", NetID);
            string value = cmd.ExecuteScalar().tostring();
            if (value != null)
               return true;
           else
               return false;
        }
    }
 }
