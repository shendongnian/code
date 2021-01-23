    Database db = DatabaseFactory.CreateDatabase();
    string spName = "MySP";
    var parameters = new object[] { "Information", 22 };
            
    int value = (int)db.ExecuteScalar(spName, parameters);
