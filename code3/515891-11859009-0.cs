    try
    {
        sqlid = new SqlCommand("SELECT TOP 1 Proj_id FROM Proj_details 
                               WHERE Front_end = '" + strfrontend 
                               + "'ORDER BY Date_time desc", con
                               ); 
        id = sqlid.ExecuteScalar().ToString();
    }
    catch(exception)
    {
       // do something with the exception
    }
