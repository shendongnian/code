	[TestMethod]
	public void TestConvert()
	{
		List<string> myList = new List<string>() { "Hello", "World" };
        //proxy a List<string>
		DynamicProxy<List<string>> proxy1 =
			new DynamicProxy<List<string>>(myList);
		dynamic proxyDynamic = proxy1;
        //dynamic 'cast' to IEnumerable<string>
		IEnumerable<string> fromDynamic = (IEnumerable<string>)proxyDynamic;
        //if the dynamic code works - it should return the same instance
        //that was passed into the DynamicProxy
		Assert.AreSame(myList, fromDynamic);
	}
