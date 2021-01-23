	public static Dictionary<string, TValue> ToDictionary<TValue>(object obj)
	{		
		var json = JsonConvert.SerializeObject(obj);
		var dictionary = JsonConvert.DeserializeObject<Dictionary<string, TValue>>(json);	
		return dictionary;
	}
