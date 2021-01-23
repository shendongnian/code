    public void foo()
    {
        using(IDbConnection connection = new MySqlConnection(/*connection string*/))
        {
            connection.Open();
            using(IDbTransction transaction = connection.BeginTransaction())
            {
                bar(connection);
                insertStuff(connection);
                
                transaction.Commit();
            }
    
        }
    }
    
    public void bar(IDbConnection connection)
    {
            insertStuff(connection);
            insertStuff(connection);
    }
    
    private void insertStuff(IDbConnection connection)
    {
         // do stuff
    }
