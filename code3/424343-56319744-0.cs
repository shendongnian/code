    public static async Task<(bool IsSuccess, Exception Error)> RunTaskInParallel(Func<Task> task, int numberOfParallelExecutions = 2)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            Exception error = null;
            int tasksCompletedCount = 0;
            var result = Parallel.For(0, numberOfParallelExecutions, GetParallelLoopOptions(cancellationTokenSource),
                          async index =>
                          {
                              try
                              {
                                  await task();
                              }
                              catch (Exception ex)
                              {
                                  error = ex;
                                  cancellationTokenSource.Cancel();
                              }
                              finally
                              {
                                  tasksCompletedCount++;
                              }
                          });
            int spinWaitCount = 0;
            int maxSpinWaitCount = 100;
            while (numberOfParallelExecutions > tasksCompletedCount && error is null && spinWaitCount < maxSpinWaitCount))
            {
                await Task.Delay(TimeSpan.FromMilliseconds(100));
                spinWaitCount++;
            }
            return (error == null, error);
        }
