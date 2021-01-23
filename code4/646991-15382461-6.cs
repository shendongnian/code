    [TestMethod]
    public void TestConvert2()
    {
      List<string> myList = new List<string>() { "Hello", "World" };
      DynamicProxy<IEnumerable<string>> proxy =
        new DynamicProxy<IEnumerable<string>>(myList);
      
      dynamic proxyDynamic = proxy;
      var fromDynamic = (IEnumerable<string>)proxyDynamic;
      Assert.AreSame(myList, fromDynamic);      
    }
