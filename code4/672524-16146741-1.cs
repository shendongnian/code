    private OleDbConnection Connect(string username, string password)
    {
        string CONNSTRING = "Provider = MSDAORA; Data Source = ISDQA; User ID = {0}; Password = {1};";
        OleDbConnection conn = new OleDbConnection();
        string strCon = string.Format(CONNSTRING, username, password);
        conn.ConnectionString = strCon;
        
        try
        {
            conn.Open();
            if (conn.State.ToString() == "Open")
                return conn;
        }//try
        catch (Exception ex)
        {
            lblErr.Text = "Connection error";
        }//catch
        finally
        {
            //you don't want to close it here
            //conn.Close();
        }//finally
        return null;
    }
