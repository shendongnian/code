    private async Task<T> ExecuteAsync<T>(RestRequest request)
    {
        var tcs = new TaskCompletionSource<T>();
        _client.ExecuteAsync(request, resp =>
        {
            var value = JsonConvert.DeserializeObject<T>(resp.Content);
            if (value.ErrorCode > 0)
            {
                var ex = new ToodledoException(value.ErrorCode, value.ErrorDesc);
                tcs.SetException(ex);
            }
            else
                tcs.SetResult(value);
        });
        return await tcs.Task;
    }
