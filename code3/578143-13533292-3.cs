    // The lock.
    var l = new object();
    // The action, can be a method, makes it easier to share.
    Action<string> a = i => {
        // Ensure one call at a time.
        lock (l) Console.WriteLine(i);
    };
    // And so on...
