    using(OleDbConnection cn = SqlClassHelper.GetDatabaseConnection(constring))
    {
        // define here your OleDbCommand, OleDbDataReader etc...
        // use the objects
    } // <- here the closing brace close and destroy the connection
   
