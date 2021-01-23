    public Poco Foo(long id)
    {
        try
        {
            using (SqlConnection SqlConn = new SqlConnection(ConnString))
            {
                // execute your commands and do your stuff
                return Poco;
            }
        }
        catch (Exception ex)
        {
            Logger.Log(ex.ToString());
            return null;
        }
    }
