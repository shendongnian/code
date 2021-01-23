    public static class FriendlyTaskRunner
    {
      public static async Task<T> Execute<T>(Func<CancellationToken, IProgress<string>, Task<T>> operation)
      {
        var cancellationTokenSource = new CancellationTokenSource();
        var progress = new Progress<string>();
        var timeout = Task.Delay(1000);
        var operationTask = operation(cancellationTokenSource.Token, progress);
        // Synchronously block for either the operation to complete or a timeout;
        //  if the operation completes first, just return the result.
        var completedTask = Task.WhenAny(timeout, operationTask).Result;
        if (completedTask == operationTask)
          return await operationTask;
        // Kick off a progress form and have it close when the task completes.
        using (var progressForm = new ProgressForm(cancellationTokenSource, progress))
        {
          operationTask.ContinueWith(_ => { progressForm.Close(); });
          progressForm.ShowDialog();
        }
        return await operationTask;
      }
    }
