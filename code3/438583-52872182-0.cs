    public static async Task WhenAll(this IEnumerable<Task> tasks, TimeSpan timeout)
    {
      // Create a timeout task.
      var timeoutTask = Task.Delay(timeout);
      // Get the completed tasks made up of...
      var completedTasks =
      (
        // ...all tasks specified
        await Task.WhenAll(tasks
        // Now finish when its task has finished or the timeout task finishes
        .Select(task => Task.WhenAny(task, timeoutTask)))
      )
      // ...but not the timeout task
      .Where(task => task != timeoutTask);
      // And wait for the internal WhenAll to complete.
      await Task.WhenAll(completedTasks);
    }
