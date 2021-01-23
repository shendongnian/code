    private bool UserExiest(string username)
    {
        SqlConnection myConnection = new SqlConnection("user id=test;" +
                "password=test;" +
                "server=.;" +
                "Trusted_Connection=yes;" +
                "database=DB; " +
                "MultipleActiveResultSets=True;" +
                "connection timeout=30");
        try
        {
            myConnection.Open();
            SqlCommand CHECKNPC = new SqlCommand("select struserid from USERDATA where strUserId = '" + username + "'", myConnection);
            SqlDataReader NpcReader = CHECKNPC.ExecuteReader();
            return NpcReader.HasRows;
        }
        finally
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }
    }
