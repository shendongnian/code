    List<TestClass> tcList = new List<TestClass>();
    tcList.Add(new TestClass { ModulePosition = 1, TopBotData = 2, prop3 = 3 });
    tcList.Add(new TestClass { ModulePosition = 1, TopBotData = 4, prop3 = 5 });
    tcList.Add(new TestClass { ModulePosition = 1, TopBotData = 2, prop3 = 6 });
    var results = new List<TestClass>(GetTests(tcList));
    var count = results.Count;
