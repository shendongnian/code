		public static T Read<T>(this IDictionary<string, object> dr, string field, T defaultValue)
		{
			return dr[field] is T ? (T)dr[field] : defaultValue;
		}
		public static T Read<T>(this IDictionary<string, object> dr, string field)
		{
			return dr[field] is T ? (T)dr[field] : default(T);
		}
