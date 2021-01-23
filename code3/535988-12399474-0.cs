    public static List<Dictionary<string, object>> SearchList(this List<Dictionary<string, object>> list,
			Dictionary<string, object> searchPattern)
		{
			return list.Where(item =>
				searchPattern.All(x => item.ContainsKey(x.Key) && 
					x.Value.Equals(item[x.Key])
				)).ToList();
		}
