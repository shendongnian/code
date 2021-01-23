    List<object> expectedResult = new List<object>();
    expectedResult.Add("zero");
    expectedResult.Add("one");
    expectedResult.Add("two");
    object result = ExecuteScript("return ['zero', 'one', 'two'];");
    Assert.IsTrue(result is ReadOnlyCollection<object>, "result was: " + result + " (" + result.GetType().Name + ")");
    ReadOnlyCollection<object> list = (ReadOnlyCollection<object>)result;
    Assert.IsTrue(CompareLists(expectedResult.AsReadOnly(), list));
