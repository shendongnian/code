    public async Task<Results> ProcessDataAsync(MyData data)
    {
        var client = await GetClientAsync();
        await client.UploadDataAsync(data);
        await client.CalculateAsync();
        return client.GetResultsAsync();
    }
