    static async Task<int> SumPageSizesAsync(IEnumerable<string> uris)
    {
      // Start one Task<byte[]> for each download.
      var tasks = uris.Select(uri => new WebClient().DownloadDataTaskAsync(uri));
      // Asynchronously wait for them all to complete.
      var results = await TaskEx.WhenAll(tasks);
      // Calculate the sum.
      return results.Sum(result => result.Length);
    }
