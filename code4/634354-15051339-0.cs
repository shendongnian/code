    class test
    {
        public string testCHECK(SqlCeConnection sqlCEconn)
        {
            if (sqlCEconn.State == ConnectionState.Open)
            {
                return "Database connection: Open";
            }
            if (sqlCEconn.State == ConnectionState.Closed)
            {
                return "Database connection: Closed";
            }
            else
            {
                return "";
            }
        }
    }
