	public static class Ex
	{
		public static void IfBounded<T>(this T[] @this, int index, Action<T> action)
		{
			if (@this == null) throw new System.ArgumentNullException("@this");
			if (action == null) throw new System.ArgumentNullException("action");
			if (index >= @this.GetLowerBound(0) && index <= @this.GetUpperBound(0))
			{
				action(@this[index]);
			}
		}
	}
