    private void sqlQuery(Action action)
    {
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
        try
        {
            //open SQL connection
            conn.Open();
            action();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Write(ex.ToString());
        }
        finally
        {
            conn.Close();
        }
    }
