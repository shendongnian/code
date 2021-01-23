    public SqlConnection CreateConnection(string username, string password)
    {
         return new SqlConnection("user id=" + username + ";" +
                                           "password=" + password + ";server=PANDORA;" +
                                           "Trusted_Connection=yes;" +
                                           "database=NHS; " +
                                           "connection timeout=30");
    }
       
