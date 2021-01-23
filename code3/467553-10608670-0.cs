    if (response.Content != null)
    {
        response.Content.ReadAsStringAsync().ContinueWith((task) =>
                { 
                    info.Content = task.Result;
                    _repository.LogResponse(info);
                }
            );
    }
