    public SqlConnection CreateConnection()
    {
         return new SqlConnection("user id=" + us + ";" +
                                           "password=" + pas + ";server=PANDORA;" +
                                           "Trusted_Connection=yes;" +
                                           "database=NHS; " +
                                           "connection timeout=30");
    }
