    public static class TaskExtensions
    {
        public static void Join(this Task task)
        {
            var currentDispatcher = Dispatcher.CurrentDispatcher;
            while (!task.IsCompleted)
            {
                // Make the dispatcher allow this thread to work on other things
                currentDispatcher.Invoke(delegate { }, DispatcherPriority.SystemIdle);
            }
        }
    }
