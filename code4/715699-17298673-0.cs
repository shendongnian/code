    var task = Task.Factory.StartNew(() =>
    {
        throw new Exception("Test");
    });
    task.ContinueWith(t => handleException(t.Exception), TaskContinuationOptions.OnlyOnFaulted);
