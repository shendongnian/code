    //Return all items from a IEnumerable(target) that has at least one matching Property(propertyName) 
    //with its value contained in a IEnumerable(possibleValues)
    static IEnumerable GetFilteredList(IEnumerable target, string propertyName, IEnumerable searchValues)
    {
    	//Get target's T 
    	var targetType = target.GetType().GetGenericArguments().FirstOrDefault();
    	if (targetType == null)
    		throw new ArgumentException("Should be IEnumerable<T>", "target");
    
    	//Get searchValues's T
    	var searchValuesType = searchValues.GetType().GetGenericArguments().FirstOrDefault();
    	if (searchValuesType == null)
    		throw new ArgumentException("Should be IEnumerable<T>", "searchValues");
    
    	//Create a p parameter with the type T of the items in the -> target IEnumerable<T>
    	var containsLambdaParameter = Expression.Parameter(targetType, "p");
    
    	//Create a property accessor using the property name -> p.#propertyName#
    	var property = Expression.Property(containsLambdaParameter, targetType, propertyName);
    
    	//Create a constant with the -> IEnumerable<T> searchValues
    	var searchValuesAsConstant = Expression.Constant(searchValues, searchValues.GetType());
    
    	//Create a method call -> searchValues.Contains(p.Id)
    	var containsBody = Expression.Call(typeof(Enumerable), "Contains", new[] { searchValuesType }, searchValuesAsConstant, property);
    
    	//Create a lambda expression with the parameter p -> p => searchValues.Contains(p.Id)
    	var containsLambda = Expression.Lambda(containsBody, containsLambdaParameter);
    
    	//Create a constant with the -> IEnumerable<T> target
    	var targetAsConstant = Expression.Constant(target, target.GetType());
    
    	//Where(p => searchValues.Contains(p.Id))
    	var whereBody = Expression.Call(typeof(Enumerable), "Where", new[] { targetType }, targetAsConstant, containsLambda);
    
    	//target.Where(p => searchValues.Contains(p.Id))
    	var whereLambda = Expression.Lambda<Func<IEnumerable>>(whereBody).Compile();
    	
    	return whereLambda.Invoke();
    }
