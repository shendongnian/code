private bool CreateDatabase(string databaseName)
{
    bool databaseCreated = false;
    try
    {
        Microsoft.SqlServer.Management.Smo.Server sqlServer = 
            new Microsoft.SqlServer.Management.Smo.Server(_connection);
        Database createdDatabase = new Database();
        createdDatabase.Name = databaseName;
        createdDatabase.Parent = sqlServer;
        createdDatabase.Create();
        databaseCreated = true;
    }
    catch (Exception ex)
    {
    }
    return databaseCreated;
}
