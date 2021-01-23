    SqlConnection myConnection = new SqlConnection(myConnString); 
    try
    {
       myConnection.Open();
    }
    catch(SqlException ex)
    {
       //Failure to open
    }
    finally
    {
       myConnection.Dispose();
    }
