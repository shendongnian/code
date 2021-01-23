    try
    {
        return Task.FromResult(model.Deserialize(stream, null, type));
    }
    catch (Exception ex)
    {
        // There's no Task.FromException, unfortunately.
        var tcs = new TaskCompletionSource<object>();
        tcs.SetException(ex);
        return tcs.Task;
    }
