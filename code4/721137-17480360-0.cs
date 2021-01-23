    public static Task<Tuple<TwitterSearchResult, TwitterResponse>> SearchAsync(this TwitterService service, SearchOptions options)
    {
      var tcs = new TaskCompletionSource<Tuple<TwitterSearchResult, TwitterResponse>>();
      service.Search(options, (status, response) => tcs.SetResult(Tuple.Create(status, response)));
      return tcs.Task;
    }
