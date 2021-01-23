	IEnumerable<MyEnum> arr = new MyEnum[] { MyEnum.first, MyEnum.second };
	var bytes = Enumerable.Cast<byte>(arr);
	foreach (var b in bytes)
	{
		Console.WriteLine(b);
	}
	
