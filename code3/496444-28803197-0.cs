	/// <summary>
	/// Get the minimum element, based on some property, like a distance or a price.
	/// </summary>
	static public T MinElement<T>(this IEnumerable<T> list, System.Func<T, float> selector)
	{
		T ret = default(T);
		float minValue = float.MaxValue;
		foreach (T elem in list)
		{
			float value = selector(elem);
			if (value <= minValue)
			{
				ret = elem;
				minValue = value;
			}
		}
		return ret;
	}
