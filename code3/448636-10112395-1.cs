	public static IEnumerable<T> MaskToList<T>(T mask) where T : Enum
	{
		return Enum.GetValues(typeof(T))
                             .Cast<T>()
                             .Where(m => mask.HasFlag(m));
	}
