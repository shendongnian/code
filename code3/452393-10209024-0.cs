    private static MySqlConnection conn;
    private static int maxRetries;
    private static void connect()
    {
        conn = <connect code>;
    }
    private static MySqlConection GetConnectionRetry(int count)
    {
        if (conn != null && conn.State == Open)
        {
            try
            {
                conn.Ping();
                return conn;
            }
            catch (Exception e) // better be specific here
            {
                if (count <= maxRetries)
                {
                    connect();
                    return GetConnectionRetry(count + 1);
                }
                else throw e;
            }
        }
        else
        {
            connect();
            return GetConnectionRetry(count + 1);
        }
    }
    static MySqlConnection GetConnection()
    {
        return GetConnectionRetry(1);
    }
