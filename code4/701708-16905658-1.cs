    SqlConnection conn = null;
    try
    {
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PrimaryDatabase"].ConnectionString);
        conn.Open();
        // do stuff
        conn.Close();
    }
    catch (SqlException ex)
    {
        try 
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BackupDatabase"].ConnectionString);
            conn.Open();
            // do stuff
            conn.Close();
        }
        catch
        {
            // log or handle error
        }
    }
