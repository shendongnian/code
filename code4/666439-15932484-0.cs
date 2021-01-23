    public IDbConnection ConnectionCreate()
    {
        IDbConnection dbConnection = new SQLiteConnection("Data Source=:memory:;pooling = true;");
        dbConnection.Open();
        return dbConnection;
    }
    
    public void Select()
    {
    	using (IDbConnection dbConnection = ConnectionCreate())
        {
        	var query = @"SELECT e1.id as Value, e1.name as Text, CASE WHEN EXISTS
    						(SELECT TOP 1 1 FROM Entity e2 WHERE e2.parent = e1.id) 
    						THEN 1 ELSE 0 END as HasChildren
    					FROM Entity e1";
            var productDto = dbConnection.Query<TreeViewDTO>(query);
        }
    }
