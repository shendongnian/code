    object storeLockId = new object();
    sessionStateContainer.Add("SomeKey", "SomeValue");
    var test = sessionStateContainer["SomeKey"];
    Console.WriteLine("var test: " + test.ToString());
    
    sessionState.Add("AnotherKey", "SomeOtherValue");
    var test2 = sessionState["AnotherKey"];
    Console.WriteLine("var test2: " + test2.ToString()); 
    
    // End the request
    provider.SetAndReleaseItemExclusive (context, sessionStateContainer.SessionID, 
                                         storeData, storeLockId, true);
    provider.EndRequest(context);
