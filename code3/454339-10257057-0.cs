	public static double[] Percentage<T>(this T[] array, Func<T,double> selector)
	{
		var doubles = array.Select(selector);
		var sum = doubles.Sum();
		
		var result = doubles.Select(x => x * 100 / sum).ToArray();
		
		return result;
	}
