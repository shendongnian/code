    public Task<IEnumerable<MyService.Character>> GetCharactersTaskAsync(this ServiceClient client)
    {
      var tcs = new TaskCompletionSource<IEnumerable<MyService.Character>>();
      client.GetCharactersCompleted += (s, e) =>
      {
        if (e.Error != null) tcs.SetException(e.Error);
        else if (e.Cancelled) tcs.SetCanceled();
        else tcs.SetResult(e.Result);
      };
      client.GetCharactersAsync();
      return tcs.Task;
    }
