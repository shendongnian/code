    /// <summary>
    /// Extends the System.Threading.Tasks.Task by automatically throwing the first exception to the main application thread.
    /// </summary>
    public class TaskEx
    {
        public Task Task { get; private set; }
        private TaskEx(Action action)
        {
            Task = Task.Factory.StartNew(action).ContinueWith((task) =>
            {
                ThrowTaskException(task);
            });
        }
        public static TaskEx StartNew(Action action)
        {
            if (action == null)
            {
                throw new ArgumentNullException();
            }
            return new TaskEx(action);
        }
        public TaskEx ContinueWith(Action<Task> continuationAction)
        {
            if (continuationAction == null)
            {
                throw new ArgumentNullException();
            }
            Task = Task.ContinueWith(continuationAction).ContinueWith((task) =>
            {
                ThrowTaskException(task);
            });
            return this;
        }
        private void ThrowTaskException(Task task)
        {
            if (task.IsFaulted)
            {
                App.Current.Dispatcher.Invoke(new Action(() =>
                {
                    throw task.Exception.InnerExceptions.First();
                }));
            }
        }
    }
