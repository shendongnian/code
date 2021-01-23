    if (callAsync)
    {
        var result = foo.BeginInvoke(...);
        // ...
    }
    else
    {
        foo.Invoke(...);
        // ...
    }
