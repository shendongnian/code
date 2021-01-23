	public static string JoinNonEmpty(string separator, params string[] values)
	{
		return 
			string.Join(separator, values.Where(v => !string.IsNullOrEmpty(v)));
		
	}
