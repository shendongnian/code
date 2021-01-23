    var client = new HttpClient();
    client.DefaultRequestHeaders.Accept.Add(...);
    return client.GetStringAsync(url).ContinueWith(task =>
    {
        if (task.IsFaulted)
        {
            var ex = task.Exception;
        }
        else if (task.IsCancelled)
        {
        }
        else
        {
            return task.Result;
        }
    });
