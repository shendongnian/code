    try{
        DataTable results = GetDataForSql("SELECT * FROM Table;", ApplicationSettings["ConnectionString"]);
    }
    catch(Exception e)
    {
        //Logging
        //Alert to user that command failed.
    }
