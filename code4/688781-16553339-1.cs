	public static class NullableHelper
	{
		public static string ToString<T>(this T? x, string format) where T: struct 
		{
			return x.HasValue ? string.Format(format, x.Value) : null;
		}
	}
