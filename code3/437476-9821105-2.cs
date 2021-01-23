    if (HttpRuntime.Cache["xyz"] == null)
    // Impossible to make a distinction between whether or not the cache value is missing
    // or if it is present but explicitly a null value...
    HttpRuntime.Cache["xyz"] = Option<String>.None();
    // We have now explicitly stated that the cache contains xyz but the value is null...
    HttpRuntime.Cache["xyz"] = Option<String>.Some("hello world");
    if (HttpRuntime.Cache["xyz"].IsSome)
    {
        // cache contains a non-null value for xyz...
    }
