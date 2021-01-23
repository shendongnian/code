    var statement = new Statement();
    
    using (var scope = new TransactionScope())
    {
    	var result = 0;
    	foreach (var statement in arr.Cast<Statement>())
    	{
    		using (var db = new ModelContainer())
    		{
    			db.StatementTypes.Attach(statement.StatementType);
    			db.Entry(statement.StatementType).State = EntityState.Unchanged;
    
    			db.Currencies.Add(statement.Currency);
    			db.Entry(statement.Currency).State = EntityState.Unchanged;
    
    			db.Subjects.Attach(statement.Firm);
    			db.Entry(statement.Firm).State = EntityState.Unchanged;
    
    			db.Statement.Add(statement);
    
    			db.SaveChanges();
    		}
    	}
    	scope.Complete();
