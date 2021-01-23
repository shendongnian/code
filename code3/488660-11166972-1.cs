    using(DatabaseConnection dbConn = new DatabaseConnection()
    {
        dbConn.Open();
        // Process your calls and data
        dbConn.Close();
    }
    // The object is Disposable and it's resources are cleared 
