	Options = someList.Select(x=>x.KEY).Select(x => CreateObject(x, someOtherList));
	public YourObject(or dynamic) CreateObject(YourObject x, List<SomeOtherObject> someOtherList)
	{
		var other = someOtherList.FirstOrDefault(y => y.KEY == x);
		
		return new
		{
			Title = (other == null ? null : other.Title),
			Foo = (other == null ? null : other.Foo),
			...
		}
	}
