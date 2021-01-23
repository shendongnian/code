    ...
    using FirebirdSql.Data.Firebird;
    ...
       
    Hashtable creationParametes = new Hashtable();
    
    creationParametes.Add("ServerType", "0");
    creationParametes.Add("User", "sysdba");
    creationParametes.Add("Password", "m*******y");
    creationParametes.Add("DataSource", "COMPUTER_WITH_DATABASE");
    creationParametes.Add("Database", @"c:\database.fdb");
    
    FbConnection.CreateDatabase( creationParametes );
