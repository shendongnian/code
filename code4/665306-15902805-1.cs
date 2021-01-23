    public Task WriteAsync(string text) // no "async"
    {
        // validation
        if (text == null)
            throw new ArgumentNullException("text", "Text must not be null.");
   
        if (some condition)
            return Task.FromResult(0); // or similar; also returning a pre-existing
                                       // Task instance can be useful
        return WriteAsyncImpl(text);
    }
