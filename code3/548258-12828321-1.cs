    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Common;
    
    ...
    
    // Connect to the default instance
    Server server = new Server();
    // Establish new database details
    Database database = new Database(server, "MyTempDB");
    // Add primary filegroup details
    database.FileGroups.Add(new FileGroup(database, "PRIMARY"));
    // Set Primary datafile properties
    DataFile primaryFile = new DataFile(database.FileGroups["PRIMARY"],
        "MyTempDB_Data", "C:\\MyTempDB.mdf");
    primaryFile.Size = 2048;   // Sizes are in KB
    primaryFile.GrowthType = FileGrowthType.Percent;
    primaryFile.Growth = 10;
    // Add to the Primary filegroup
    database.FileGroups["PRIMARY"].Files.Add(primaryFile);
    // Define the log file
    LogFile logfile = new LogFile(database, "MyTempDB_Log", "C:\\MyTempDB_Log.ldf");
    logfile.Size = 1024;
    logfile.GrowthType = FileGrowthType.Percent;
    logfile.Growth = 10;
    logfile.MaxSize = 70 * 1024;
    // Add to the database
    database.LogFiles.Add(logfile);
    // Create
    database.Create();
    database.Refresh();
