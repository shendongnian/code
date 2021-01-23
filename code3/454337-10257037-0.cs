	public static IEnumerable<double> Percentage(this IEnumerable<int> values)
	{
		var sum = values.Sum();
		return values.Select(v => (double)v / (double)sum);
	}
	
	public static IEnumerable<double> Percentage(this IEnumerable<long> values)
	{
		var sum = values.Sum();
		return values.Select(v => (double)v / (double)sum);
	}
	
	public static IEnumerable<double> Percentage(this IEnumerable<double> values)
	{
		var sum = values.Sum();
		return values.Select(v => v / sum);
	}
