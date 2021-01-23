    public Task WriteAsync(string text) // no "async"
    {
        // validation
        if (text == null)
            throw new ArgumentNullException("text", "Text must not be null.");
    
        return WriteAsyncImpl(text);
    }
    private async Task WriteAsyncImpl(string text)
    {
        // async stuff...
    }
