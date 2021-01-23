    async Task<DataSet> ScrapeDataAsync(Uri url)
    {
        // Create the HttpClientHandler which will handle cookies.
        var handler = new HttpClientHandler();
        // Set cookies on handler.
        // Await on an async call to fetch here, convert to a data
        // set and return.
        var client = new HttpClient(handler);
        // Wait for the HttpResponseMessage.
        HttpResponseMessage response = await client.GetAsync(url);
        // Get the content, await on the string content.
        string content = await response.Content.ReadAsStringAsync();
        // Process content variable here into a data set and return.
        DataSet ds = ...;
        // Return the DataSet, it will return Task<DataSet>.
        return ds;
    }
