    EventWaitHandle Wait = new AutoResetEvent(false);
    client.ExecuteAsync(request, response =>
    {
        if (response.ResponseStatus == ResponseStatus.Completed)
        {
            RestResponse resource = response;
            string content = resource.Content;
            resp = Convert.ToBoolean(JsonHelper.FromJson<string>(content));
            Wait.Set();
        }
    });
    Wait.WaitOne();
