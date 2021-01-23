    using OdbcConnection conn = new OdbcConnection(
        string.Format("DSN={0};Uid={1};Pwd={2}", theDSN, theUsername, thePassword)
        )
    {
        try
        {
            conn.Open();
            conn.Close();
            /* success */
        }
        catch (Exception e)
        {
            /* failure */
        }
    }
