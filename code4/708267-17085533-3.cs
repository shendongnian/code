    private static IDbConnection GetConnection()
    {
        try
        {
            var connection = new WhateverConnection(yourConnectionString);
            connection.Open();
            return connection;
        }catch(Exception ex) {}
    }
