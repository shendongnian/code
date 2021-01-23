public static class Ext {
	public static Dictionary<string, object> ToDict<T>(this T target)
		=> target is null
			? new Dictionary<string, object>()
			: typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public)
						.ToDictionary(
							x => x.Name,
							x => x.GetValue(target)
						);
}
