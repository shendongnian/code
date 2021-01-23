    static class TaskEx
    {
        public static Task ObserverExceptions(this Task task)
        {
            task.ContinueWith(t => { var ignore = t.Exception; },
                                TaskContinuationOptions.OnlyOnFaulted);
            return task;
        }
    }
