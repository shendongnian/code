    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Hosting;
    using Nito.AsyncEx;
    /// <summary>
    /// A type that tracks background operations and notifies ASP.NET that they are still in progress.
    /// </summary>
    public sealed class BackgroundTaskManager : IRegisteredObject
    {
        /// <summary>
        /// A cancellation token that is set when ASP.NET is shutting down the app domain.
        /// </summary>
        private readonly CancellationTokenSource shutdown;
        /// <summary>
        /// A countdown event that is incremented each time a task is registered and decremented each time it completes. When it reaches zero, we are ready to shut down the app domain. 
        /// </summary>
        private readonly AsyncCountdownEvent count;
        /// <summary>
        /// A task that completes after <see cref="count"/> reaches zero and the object has been unregistered.
        /// </summary>
        private readonly Task done;
        private BackgroundTaskManager()
        {
            // Start the count at 1 and decrement it when ASP.NET notifies us we're shutting down.
            shutdown = new CancellationTokenSource();
            count = new AsyncCountdownEvent(1);
            shutdown.Token.Register(() => count.Signal(), useSynchronizationContext: false);
            // Register the object and unregister it when the count reaches zero.
            HostingEnvironment.RegisterObject(this);
            done = count.WaitAsync().ContinueWith(_ => HostingEnvironment.UnregisterObject(this), TaskContinuationOptions.ExecuteSynchronously);
        }
        void IRegisteredObject.Stop(bool immediate)
        {
            shutdown.Cancel();
            if (immediate)
                done.Wait();
        }
        /// <summary>
        /// Registers a task with the ASP.NET runtime.
        /// </summary>
        /// <param name="task">The task to register.</param>
        private void Register(Task task)
        {
            count.AddCount();
            task.ContinueWith(_ => count.Signal(), TaskContinuationOptions.ExecuteSynchronously);
        }
        /// <summary>
        /// The background task manager for this app domain.
        /// </summary>
        private static readonly BackgroundTaskManager instance = new BackgroundTaskManager();
        /// <summary>
        /// Gets a cancellation token that is set when ASP.NET is shutting down the app domain.
        /// </summary>
        public static CancellationToken Shutdown { get { return instance.shutdown.Token; } }
    
        /// <summary>
        /// Executes an <c>async</c> background operation, registering it with ASP.NET.
        /// </summary>
        /// <param name="operation">The background operation.</param>
        public static void Run(Func<Task> operation)
        {
            instance.Register(Task.Run(operation));
        }
        /// <summary>
        /// Executes a background operation, registering it with ASP.NET.
        /// </summary>
        /// <param name="operation">The background operation.</param>
        public static void Run(Action operation)
        {
            instance.Register(Task.Run(operation));
        }
    }
