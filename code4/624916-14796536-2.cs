		public static T Read<T>(this IDictionary<string, object> dr, string field, T defaultValue)
		{
			var v = dr[field];
			return v is T ? (T)v : defaultValue;
		}
		public static T Read<T>(this IDictionary<string, object> dr, string field)
		{
			var v = dr[field];
			return v is T ? (T)v : default(T);
		}
