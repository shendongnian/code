    public interface ITaskRunner
    {
        Task<TNewResult> Execute<TResult, TNewResult>(Func<TResult> action, Func<Task<TResult>, TNewResult> continueWith);
    }
    public class TaskRunner : ITaskRunner
    {
        public Task<TNewResult> Execute<TResult, TNewResult>(Func<TResult> action, Func<Task<TResult>, TNewResult> continueWith)
        {
            return Task.Factory.StartNew(action).ContinueWith(continueWith);
        }
    }
