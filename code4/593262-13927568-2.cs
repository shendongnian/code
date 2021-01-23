    class dataUtility
    {
     string connection = WebConfigurationManager.ConnectionStrings["Name Of your   Connection"].ConnectionString;
    
    Public void Insert()
    {
    sqlconnection con=new sqlconnection(connection);
    ...
    }
    }
