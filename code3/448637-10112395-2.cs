	public static IEnumerable<T> MaskToList<T>(Enum mask)
	{
		if (typeof(T).IsSubclassOf(typeof(Enum)) == false)
			throw new ArgumentException();
		return Enum.GetValues(typeof(T))
                             .Cast<Enum>()
                             .Where(m => mask.HasFlag(m))
                             .Cast<T>();
	}
