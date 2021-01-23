    if (response.Content != null)
    {
        var task = response.Content.ReadAsStringAsync().ContinueWith((task) =>
                           { 
                               info.Content = task.Result;
                           });
        task.Wait();
    }
    _repository.LogResponse(info);
