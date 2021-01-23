    Server srv1 = new Server("<server_location>");
    srv1.ConnectionContext.LoginSecure = false;
    srv1.ConnectionContext.Login = "<username>";
    srv1.ConnectionContext.Password = "<password>";
    srv1.ConnectionContext.Connect();
    Database sourceDb = srv1.Databases["<database_name>"];
    Table sourceTbl = sourceDb.Tables["<table_name>"];
            
    Server srv2 = new Server("<server_location>");
    srv2.ConnectionContext.LoginSecure = false;
    srv2.ConnectionContext.Login = "<username>";
    srv2.ConnectionContext.Password = "<password>";
    srv2.ConnectionContext.Connect();
    Database destinationDb = srv1.Databases["<database name>"];
    Table destinationTbl = sourceDb.Tables["<table_name>"];
    var isMatched = CompareTables(sourceTbl, destinationTbl);    
