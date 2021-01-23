        IsPartialMatch(Marble m1, Marble m2)
	{
		PropertyInfo[] properties = m1.GetType().GetProperties();
		foreach (PropertyInfo property in properties)
		{
            if (property.GetValue(m1, null) == GetDefault(property.GetType()) continue;
            if (property.GetValue(m2, null) == GetDefault(property.GetType()) continue;
			if (property.GetValue(m1, null) != property.GetValue(m2, null))
				return false;
		}
		
		return true;
	}
