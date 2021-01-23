	foreach (var t in tests)
    {
        var test = (dynamic)Activator.CreateInstance(t);
        
		test.SetupTest();
		t.GetField("driver", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(test, new ChromeDriver());
        t.GetMethod(String.Format("The{0}Test", t.Name)).Invoke(test, null);
 		test.TeardownTest();
	 }
