    public async Task<HtmlDocument> LoadPage(Uri address)
    {
        await new SynchronizationContextRemover();
    
        using (var client = new HttpClient())
        using (var httpResponse = await client.GetAsync(address))
        using (var responseContent = httpResponse.Content)
        using (var contentStream = await responseContent.ReadAsStreamAsync())
            return LoadHtmlDocument(contentStream); //CPU-bound
    }
