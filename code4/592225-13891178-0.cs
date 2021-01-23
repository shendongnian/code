    Testentities test = new TestEntities();
    object d = test.FunctionTest("Params");
    List<string> results = new List<string>();
    foreach(object o in d)
    {
        results.Add(o.ToString());
    }
