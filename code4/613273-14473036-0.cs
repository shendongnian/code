	List<Flat> GetSavedOutput(List<Flat> items)
	{
		// get all output leaf nodes
		var toAdd = items.Where (i => i.isOutput == true).ToList();
		var result = new List<Flat>();
		
		// grab all parent nodes that are not already included until
		// there's nothing new to add
		while (toAdd.Count > 0)
		{
			result.AddRange(toAdd);
			toAdd = items.Where (i => !result.Contains(i) && result.Any (r => r.parentId == i.id)).ToList();
		}
		
		return result;
	}
