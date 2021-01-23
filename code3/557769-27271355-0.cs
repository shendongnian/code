    using System;
    using System.Threading.Tasks;
    class FaFTaskFactory
    {
        public static Task StartNew(Action action)
        {
            return Task.Factory.StartNew(action).ContinueWith(
                c =>
                {
                    AggregateException exception = c.Exception;
                    // Your Exception Handling Code
                },
                TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously
            ).ContinueWith(
			    c =>
                {
                    // Your task accomplishing Code
                },
                TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously
		    );
        }
        public static Task StartNew(Action action, Action<Task> exception_handler, Action<Task> completion_handler)
        {
            return Task.Factory.StartNew(action).ContinueWith(
                exception_handler,
                TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously
            ).ContinueWith(
			    completion_handler,
                TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously
		    );
        }
    };
