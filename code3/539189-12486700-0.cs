    Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null)
        .ContinueWith(
            t =>
            {
                using (var response = (HttpWebResponse)t.Result)
                {
                    // Do your work
                }
            },
            TaskScheduler.FromCurrentSynchronizationContext()
        );
