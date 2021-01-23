	public class MyDateTime
	{
		public DateTime This { get; set; }
	}
	public static Func<DateTime> GetFunk<T>(Expression<Func<T, DateTime>> timeOrderByFunc, T t)
	{
		return () => timeOrderByFunc.Compile()(t);
	}
