		public static T? GetNullIfDefault<T>(this T value)
			where T: struct
		{
			if( value.Equals(default(T)))
			{
				return null;
			}
			return value;
		}
