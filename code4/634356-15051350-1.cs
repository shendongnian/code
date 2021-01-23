    public string testCHECK(SqlCeConnection thisConnection)
    {
        if (thisConnection.State == ConnectionState.Open)
        {
            return "Database connection: Open";
        }
        if (thisConnection.State == ConnectionState.Closed)
        {
            return "Database connection: Closed";
        }
        else
        {
            return "";
        }
    }
