    private static bool OpenConnection(IDbConnection connection)
    {
        try
        {
            connection.Open();
            return true;
        }catch(Exception ex) {}
    }
