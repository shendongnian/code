    private static readonly HttpClient client = new HttpClient();
    public async Task Crawl(string url)
    {
      var html = await client.GetString(url);
      var nextUrls = await Task.Run(ProcessHtml(html));
      var nextTasks = nextUrls.Select(nextUrl => Crawl(nextUrl));
      await Task.WhenAll(nextTasks);
    }
    private IEnumerable<string> ProcessHtml(string html)
    {
      // return all urls in the html string.
    }
