    public async Task<Results> ProcessDataAsync(MyData data, CancellationToken token)
    {
        Client client;
        try
        {
            client = await GetClientAsync().WaitOrCancel(token);
            await client.UploadDataAsync(data).WaitOrCancel(token);
            await client.CalculateAsync().WaitOrCancel(token);
            return await client.GetResultsAsync().WaitOrCancel(token);
        }
        catch (OperationCanceledException)
        {
            if (client != null)
                await client.CancelAsync();
            throw;
        }
    }
    
