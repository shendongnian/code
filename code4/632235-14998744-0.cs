    var names = q.Split(' ');
    if(names.Any())
    {
    	var firstName = names[0];
    	
    	var query = context.Recipes.Where (q => q.Name.Contains(firstName));
    	foreach (var name in names.Skip(1))
    	{
    	    query = query.Union(context.Recipes.Where (q => q.Name.Contains(name)));
            // other unions ...
            // query = query.Union( context.Recipes.Where (...
    	}
    	
        // query evaluated now
    	var recipes = query.ToList();
    }
