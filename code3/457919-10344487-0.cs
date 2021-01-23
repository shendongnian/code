	private static decimal GetOrZero(this IDictionary<string,decimal> dict, string key)
	{
		decimal value = 0;
		dict.TryGetValue(key, out value);
		return value;
	}
	private static IDictionary<string, decimal> CalculateBalances(
		IDictionary<string, decimal> initialValue, 
		IDictionary<string, decimal> credits, 
		IDictionary<string, decimal> debits)
	{	
		var r = new Dictionary<string, decimal>();
		var accounts = initialValue.Keys.Union(debits.Keys).Union(credits.Keys);
		
		foreach (var accounts in accounts)
		{
			r.Add(initialValue.GetOrZero(key) + credits.GetOrZero(key) - debits.GetOrZero(key));
		}
		
		return r;
	}
