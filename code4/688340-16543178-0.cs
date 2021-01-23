		public static bool ObviouslyEquals<T>(this string  s, T? t) where T: struct
		{
			if (s == null && !t.HasValue)
				return true;
			return s.Equals(t.Value.ToString());
		}
    string s;
    int? i; 
    if (s.ObviouslyEquals(i))...
