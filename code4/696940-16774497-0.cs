    public static OleDbConnection GetDatabaseConnection(string aConnectionString) 
    {
        OleDbConnection odb = new OleDbConnection(aConnectionString);
        odb.Open();
        Log.Logger.log("Aperta connessione al DB");
        return odb;
    }
