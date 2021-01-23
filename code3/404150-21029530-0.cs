	public static class RouteValueDictionaryExtensions
	{
		public static RouteValueDictionary ToRouteValues(this NameValueCollection queryString)
		{
			if (queryString == null || queryString.HasKeys() == false) 
				return new RouteValueDictionary();
			var routeValues = new RouteValueDictionary();
			foreach (string key in queryString.AllKeys)
				routeValues.Add(key, queryString[key]);
			return routeValues;
		}
		public static RouteValueDictionary Set(this RouteValueDictionary routeValues, string key, string value)
		{
			routeValues[key] = value;
			return routeValues;
		}
		public static RouteValueDictionary Merge(this RouteValueDictionary primary, RouteValueDictionary secondary)
		{
			if (primary == null || primary.Count == 0)
			{
				return secondary ?? new RouteValueDictionary();
			}
			if (secondary == null || secondary.Count == 0)
				return primary;
			foreach (var pair in secondary)
				primary[pair.Key] = pair.Value;
			return primary;
		}
		public static RouteValueDictionary Merge(this RouteValueDictionary primary, object secondary)
		{
			return Merge(primary, new RouteValueDictionary(secondary));
		}
	}
