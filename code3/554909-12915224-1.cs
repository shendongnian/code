    var calls = Enumerable.Repeat<List<string>>(new List<string>() { "IsServerRunning", "StartServer" }, noOfAttempts).ToList();
    calls.ForEach(new Action<List<string>>(
        delegate(List<string> item)
        {
            // Use reflection here to create calls to the elements of item
        }
    ));
