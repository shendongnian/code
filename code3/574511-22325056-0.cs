    private bool validateConnectionString(string connString)
    {
        try
        {
            var con = new SqlConnectionStringBuilder(connString);
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                return (conn.State == ConnectionState.Open);
            }
        }
        catch
        {
            return false;
        }
    }
