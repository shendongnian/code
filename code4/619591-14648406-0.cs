    public static Task<MyProjectList> GetProjectListTaskAsync(this SomeService @this, string username, string password)
    {
      var tcs = new TaskCompletionSource<MyProjectList>();
      EventHandler<GetProjectListCompletedEventArgs> callback = null;
      callback = args =>
      {
        @this.GetProjectListCompleted -= callback;
        if (args.Cancelled) tcs.TrySetCanceled();
        else if (args.Error != null) tcs.TrySetException(args.Error);
        else tcs.TrySetResult(args.Result);
      };
      @this.GetProjectListCompleted += callback;
      @this.GetProjectListAsync(username, password);
    }
