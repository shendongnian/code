private void CreateDatabase(string databaseName)
{
    Microsoft.SqlServer.Management.Smo.Server sqlServer = 
            new Microsoft.SqlServer.Management.Smo.Server(_connection);
    Database createdDatabase = new Database();
    createdDatabase.Name = databaseName;
    createdDatabase.Parent = sqlServer;
    createdDatabase.Create();
}
