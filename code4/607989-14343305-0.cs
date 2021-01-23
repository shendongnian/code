    private static Dictionary<string, List<string>>
        GetTransformedCollection(IEnumerable<Obj1> results)
    {
		var distinctNames = results.SelectMany(val => val.Names).Distinct();
		
		return distinctNames
			  .ToDictionary(name => name, 
						    name => results
									.Where(res => res.Names.Contains(name))
									.SelectMany(res => res.Tags)
									.ToList());
    }
