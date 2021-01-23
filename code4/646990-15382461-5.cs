	[TestMethod]
	public void TestConvert()
	{
		List<string> myList = new List<string>() { "Hello", "World" };
        //proxy a List<string>
		DynamicProxy<List<string>> proxy1 =
			new DynamicProxy<List<string>>(myList);
		dynamic proxyDynamic = proxy1;
        //dynamic 'cast' to List<string> (the actual 'T')
        //should return same instance, because the conversion
        //simply gets the private 't' field.
        List<string> fromDynamic1 = (List<string>)proxyDynamic;
        Assert.AreSame(myList, fromDynamic1);
        //dynamic 'cast' to a base or interface of T
        //In this case, IEnumerable<string>
		IEnumerable<string> fromDynamic2 = (IEnumerable<string>)proxyDynamic;
		Assert.AreSame(myList, fromDynamic2);
	}
