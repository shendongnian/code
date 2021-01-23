	public static A[] ExtractElements (List<A> list, Type[] specifiers, bool orderMatters = false)
	{
		var allFound = true;
		var listBackup = list.ToList(); // Make a backup copy	
		var returnList = new List<A>();
		var earliestMatch = 0;
		
		foreach (var spec in specifiers)
		{
			var item = list.FirstOrDefault (i => spec.IsAssignableFrom(i.GetType()));
			if (item != null)
			{
				var matchPosition = list.IndexOf(item);
				if (orderMatters && matchPosition < earliestMatch)	// we have an out of order match
				{
					allFound = false;
					break;
				}
				earliestMatch = matchPosition;
				list.Remove(item);
				returnList.Add(item);
			}
			else
			{
				allFound = false;
				break;
			}
		}
		
		if(!allFound)
		{
			// Can't just assign list to listBackup because we have to update the 
			// underlying values not the reference that was passed to the function.
			list.Clear();
			listBackup.ForEach(i => list.Add(i));
			returnList.Clear();
		}
		
		return returnList.ToArray();
	}
