    var thirdList = new List<TestClass>(List2.Count + List1.Count);
    foreach (var testClass in List1)
    {
       thirdList.Add(testClass);
    }
    foreach (var testClass in List2)
    {
       thirdList.Add(testClass);
    }
    List2 = thirdList;
