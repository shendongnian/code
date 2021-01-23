    // type is type of your unflattened domain model.
    // flatProperty is property name in your flattened view model
    public string GetSortExpressionFor(Type type, string flatProperty)
    {
    	// sanity checks ommited for bervity....
    	var model = Activator.CreateInstance(type); // I really don't like this, but see no other way....
    	var parts = new List<String>();
    	var noMatch = false;
    	// Let the ValueInjector match the property while reducing the path...
    	while (true)
    	{
    		var unflat = UberFlatter.Unflat(flatProperty, model);
    		if (unflat.Count() != 1) // must be a match
    		{
    			// if there are no parts in the list then flatPath does not match anything...
    			if (!parts.Any())
    			{
    				noMatch = true;
    			}
    			break;
    		}
    		var propertyName = unflat.First().Property.Name;
    		parts.Add(propertyName);
    		flatProperty = flatProperty.Left(flatProperty.Length - propertyName.Length);
    	}
    	return path = noMatch ? String.Empty : String.Join(".", parts.ToArray().Reverse());
    }		
    		
    // sample usage		
    var flatProperty = GetSortExpressionFor(typeof(Company), "PresidentHomeAddressLine1");
    // flatProperty == "President.HomeAddress.Line1"
