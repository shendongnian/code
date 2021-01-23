    foreach (var entity in entities)
    {
    	if (entity.Id == 0)
    	{
    		// Adds to the context for a DB insert
    		context.Entities.Add(entity);
    	}
    	else
    	{
    		// Updates existing entity (property by property in this example, you could update
    		// all properties in a single shot if you want)
    		var dbEntity = context.Entities.Single(z => z.Id == entity.Id);
    		dbEntity.Prop1 = entity.Prop1;
    		// etc...
    	}
    }
    
    context.SaveChanges();
