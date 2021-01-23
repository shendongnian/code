	public static string GetFirstEqualOrHigher(TimeSpan time, IEnumerable<MyClass> targets)
	{
		return list.First(x => time >= x.time).Name;
	}
	IList<MyClass> list = new List<MyClass>
	{
		new MyClass() { Name="midnight", time = new TimeSpan(18, 0, 0) }
		new MyClass() { Name="noon", time = new TimeSpan(6, 0, 0) },
		new MyClass() { Name="midnight", time = new TimeSpan(0, 0, 0) },
	};
	var testOne = GetFirstEqualOrHigher(new TimeSpan(2, 0, 0), list); // returns midnight
	var testTwo = GetFirstEqualOrHigher(new TimeSpan(8, 0, 0), list); // returns noon
	var testThree = GetFirstEqualOrHigher(new TimeSpan(13, 0, 0), list); // returns noon
	var testFour = GetFirstEqualOrHigher(new TimeSpan(22, 0, 0), list); // returns midnight (that's the tricky one
