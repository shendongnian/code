    private static object Abs(object num)
	{
		var type = num.GetType();
		if (type == typeof(Int32))
		{
			return Math.Abs((int) num);
		}
		if (type == typeof(Int64))
			return Math.Abs((long)num);
		if (type == typeof(Int16))
			return Math.Abs((short)num);
		if (type == typeof(float))
			return Math.Abs((float)num);
		if (type == typeof(double))
			return Math.Abs((double)num);
		if (type == typeof(decimal))
			return Math.Abs((decimal)num);
		throw new ArgumentException(string.Format("Abs is not defined for type {0}", type.FullName));
	}
