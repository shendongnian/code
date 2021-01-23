    public static class AsyncExecuter
    {
        private static readonly ThreadLocal<List<Action>> TasksToExecute =
            new ThreadLocal<List<Action>>(() => new List<BackgroundTask>());
        public static Action<Exception> ExceptionHandler { get; set; }
        public static void ExecuteLater(BackgroundTask task)
        {
            TasksToExecute.Value.Add(task);
        }
        public static void Discard()
        {
            TasksToExecute.Value.Clear();
        }
        public static void StartExecuting()
        {
            var value = TasksToExecute.Value;
            var copy = value.ToArray();
            value.Clear();
            if (copy.Length > 0)
            {
                Task.Factory.StartNew(() =>
                {
                    foreach (var backgroundTask in copy)
                        ExecuteTask(backgroundTask);
                }, TaskCreationOptions.LongRunning)
                .ContinueWith(task =>
                {
                    if (ExceptionHandler != null)
                        ExceptionHandler(task.Exception);
                }, TaskContinuationOptions.OnlyOnFaulted);
            }
        }
        public static void ExecuteTask(Action task)
        {
            task.Invoke();
        }
    }
