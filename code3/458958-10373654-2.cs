    public OleDbConnection OpenDB()   
    {   
        dataConnection = new OleDbConnection();   
        dataConnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Projects_2012\\Project_Noam\\Access\\myProject.accdb";   
        dataConnection.Open();   
        return dataConnection;
    }
