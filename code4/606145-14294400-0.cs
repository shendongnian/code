    bool method1()
    {
        using (OleDbConnection con = new OleDbConnection(connString))
            {
                try
                {
                    con.Open();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    con.Close();
                }                
        }
    }
