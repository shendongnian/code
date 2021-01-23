    public async Task<Results> ProcessDataAsync(MyData data, CancellationToken token)
    {
        var client = await GetClientAsync().WaitOrCancel(token);
        await client.UploadDataAsync(data).WaitOrCancel(token);
        await client.CalculateAsync().WaitOrCancel(token);
        return client.GetResultsAsync().WaitOrCancel(token);        
    }
    
