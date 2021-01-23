    public async Task<HtmlDocument> LoadPage(Uri address)
    {
      using (var httpResponse = await new HttpClient().GetAsync(address)) //IO-bound
      using (var responseContent = httpResponse.Content)
      using (var contentStream = await responseContent.ReadAsStreamAsync()) //IO-bound
        return LoadHtmlDocument(contentStream); //CPU-bound
    }
