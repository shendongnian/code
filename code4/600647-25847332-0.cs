    public static class TaskHelper
    {
        public async static Task<T> AsAsync<T>(Func<T> function, TaskCreationOptions taskCreationOptions = TaskCreationOptions.None)
        {
            return await Task.Factory.StartNew(function, taskCreationOptions);
        }
        public async static Task AsAsync(Action action, TaskCreationOptions taskCreationOptions = TaskCreationOptions.None)
        {
            await Task.Factory.StartNew(action, taskCreationOptions);
        }
    }
