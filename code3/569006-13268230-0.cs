    public static class AsyncExecutor
        {
            public static CancellationTokenSource ExecuteBlockingOperation(Action action, Action completition, Action<AggregateException> onException)
            {
                if (action == null)
                    throw new ArgumentNullException("action");
    
                if (completition == null)
                    throw new ArgumentNullException("completition");
    
                var cts = new CancellationTokenSource();
                var token = cts.Token;
    
                var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
    
                var task = new Task(action, TaskCreationOptions.LongRunning);
                task.ContinueWith(asyncPartTask => onException(asyncPartTask.Exception), CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, scheduler);
                task.ContinueWith(asyncPart =>
                                      {
                                          if (!token.IsCancellationRequested)
                                              completition();
                                      },
                                  CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, scheduler);
                task.Start();
    
                return cts;
    
            }
    
            public static CancellationTokenSource ExecuteBlockingOperation<TIn>(Action<TIn> action, TIn parameter, Action<TIn> completition, Action<AggregateException, TIn> onException)
            {
                if (action == null)
                    throw new ArgumentNullException("action");
    
                if (completition == null)
                    throw new ArgumentNullException("completition");
    
                var cts = new CancellationTokenSource();
                var token = cts.Token;
    
                var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
    
                var task = new Task(() => action(parameter), TaskCreationOptions.LongRunning);
                task.ContinueWith(asyncPartTask => onException(asyncPartTask.Exception, parameter), CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, scheduler);
                task.ContinueWith(asyncPart =>
                                      {
                                          if (!token.IsCancellationRequested)
                                              completition(parameter);
                                      },
                                  CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, scheduler);
                task.Start();
    
                return cts;
    
            }
    
            public static CancellationTokenSource ExecuteBlockingOperation<TOut>(Func<TOut> func, Action<TOut> completition, Action<AggregateException> onException)
            {
                if (func == null)
                    throw new ArgumentNullException("func");
    
                if (completition == null)
                    throw new ArgumentNullException("completition");
    
                var cts = new CancellationTokenSource();
                var token = cts.Token;
    
                var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
    
                var task = new Task<TOut>(func, TaskCreationOptions.LongRunning);
                task.ContinueWith(asyncPartTask => onException(asyncPartTask.Exception), CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, scheduler);
                task.ContinueWith(asyncPart =>
                                      {
                                          if (!token.IsCancellationRequested)
                                              completition(asyncPart.Result);
                                      },
                                  CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, scheduler);
                task.Start();
    
                return cts;
    
            }
    
            public static CancellationTokenSource ExecuteBlockingOperation<TIn, TOut>(Func<TIn, TOut> func, TIn parameter, Action<TOut, TIn> completition, Action<AggregateException, TIn> onException)
            {
                if (func == null)
                    throw new ArgumentNullException("func");
    
                if (completition == null)
                    throw new ArgumentNullException("completition");
    
                var cts = new CancellationTokenSource();
                var token = cts.Token;
    
                var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
    
                var task = new Task<TOut>(() => func(parameter), TaskCreationOptions.LongRunning);
                task.ContinueWith(asyncPartTask => onException(asyncPartTask.Exception, parameter), CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, scheduler);
                task.ContinueWith(asyncPart =>
                {
                    if (!token.IsCancellationRequested)
                        completition(asyncPart.Result, parameter);
                },
                                  CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, scheduler);
                task.Start();
    
                return cts;
            }
    
            public static CancellationTokenSource ExecuteBlockingOperation<TIn, TOut>(Func<TIn, TOut> func, TIn parameter, Action<TOut> completition, Action<AggregateException, TIn> onException)
            {
                if (func == null)
                    throw new ArgumentNullException("func");
    
                if (completition == null)
                    throw new ArgumentNullException("completition");
    
                var cts = new CancellationTokenSource();
                var token = cts.Token;
    
                var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
    
                var task = new Task<TOut>(() => func(parameter), TaskCreationOptions.LongRunning);
                task.ContinueWith(asyncPartTask => onException(asyncPartTask.Exception, parameter), CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, scheduler);
                task.ContinueWith(asyncPart =>
                {
                    if (!token.IsCancellationRequested)
                        completition(asyncPart.Result);
                },
                                  CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, scheduler);
                task.Start();
    
                return cts;
            }
    
            public static CancellationTokenSource ExecuteBlockingOperation<TIn, TOut>(Func<TIn, TOut> func, TIn parameter, Action<TIn> completition, Action<AggregateException, TIn> onException)
            {
                if (func == null)
                    throw new ArgumentNullException("func");
    
                if (completition == null)
                    throw new ArgumentNullException("completition");
    
                var cts = new CancellationTokenSource();
                var token = cts.Token;
    
                var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
    
                var task = new Task<TOut>(() => func(parameter), TaskCreationOptions.LongRunning);
                task.ContinueWith(asyncPartTask => onException(asyncPartTask.Exception, parameter), CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, scheduler);
                task.ContinueWith(asyncPart =>
                {
                    if (!token.IsCancellationRequested)
                        completition(parameter);
                },
                                  CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, scheduler);
                task.Start();
    
                return cts;
            }
    
            public static CancellationTokenSource ExecuteBlockingOperation<TIn, TOut>(Func<TIn, TOut> func, TIn parameter, Action completition, Action<AggregateException, TIn> onException)
            {
                if (func == null)
                    throw new ArgumentNullException("func");
    
                if (completition == null)
                    throw new ArgumentNullException("completition");
    
                var cts = new CancellationTokenSource();
                var token = cts.Token;
    
                var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
    
                var task = new Task<TOut>(() => func(parameter), TaskCreationOptions.LongRunning);
                task.ContinueWith(asyncPartTask => onException(asyncPartTask.Exception, parameter), CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, scheduler);
                task.ContinueWith(asyncPart =>
                {
                    if (!token.IsCancellationRequested)
                        completition();
                },
                                  CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, scheduler);
                task.Start();
    
                return cts;
            }
    
            public static CancellationTokenSource ExecuteBlockingOperation<TIn, TOut>(Func<TIn, TOut> func, TIn parameter, Action<TIn> completition, Action<AggregateException> onException)
            {
                if (func == null)
                    throw new ArgumentNullException("func");
    
                if (completition == null)
                    throw new ArgumentNullException("completition");
    
                var cts = new CancellationTokenSource();
                var token = cts.Token;
    
                var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
    
                var task = new Task<TOut>(() => func(parameter), TaskCreationOptions.LongRunning);
                task.ContinueWith(asyncPartTask => onException(asyncPartTask.Exception), CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, scheduler);
                task.ContinueWith(asyncPart =>
                {
                    if (!token.IsCancellationRequested)
                        completition(parameter);
                },
                                  CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, scheduler);
                task.Start();
    
                return cts;
            }
    
            public static CancellationTokenSource ExecuteBlockingOperation<TIn, TOut>(Func<TIn, TOut> func, TIn parameter, Action<TOut, TIn> completition, Action<AggregateException> onException)
            {
                if (func == null)
                    throw new ArgumentNullException("func");
    
                if (completition == null)
                    throw new ArgumentNullException("completition");
    
                var cts = new CancellationTokenSource();
                var token = cts.Token;
    
                var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
    
                var task = new Task<TOut>(() => func(parameter), TaskCreationOptions.LongRunning);
                task.ContinueWith(asyncPartTask => onException(asyncPartTask.Exception), CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, scheduler);
                task.ContinueWith(asyncPart =>
                {
                    if (!token.IsCancellationRequested)
                        completition(asyncPart.Result, parameter);
                },
                                  CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, scheduler);
                task.Start();
    
                return cts;
            }
    
            public static CancellationTokenSource ExecuteBlockingOperation<TIn, TOut>(Func<TIn, TOut> func, TIn parameter, Action<TOut> completition, Action<AggregateException> onException)
            {
                if (func == null)
                    throw new ArgumentNullException("func");
    
                if (completition == null)
                    throw new ArgumentNullException("completition");
    
                var cts = new CancellationTokenSource();
                var token = cts.Token;
    
                var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
    
                var task = new Task<TOut>(() => func(parameter), TaskCreationOptions.LongRunning);
                task.ContinueWith(asyncPartTask => onException(asyncPartTask.Exception), CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, scheduler);
                task.ContinueWith(asyncPart =>
                {
                    if (!token.IsCancellationRequested)
                        completition(asyncPart.Result);
                },
                                  CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, scheduler);
                task.Start();
    
                return cts;
            }
    
            public static CancellationTokenSource ExecuteBlockingOperation<TIn, TOut>(Func<TIn, TOut> func, TIn parameter, Action completition, Action<AggregateException> onException)
            {
                if (func == null)
                    throw new ArgumentNullException("func");
    
                if (completition == null)
                    throw new ArgumentNullException("completition");
    
                var cts = new CancellationTokenSource();
                var token = cts.Token;
    
                var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
    
                var task = new Task<TOut>(() => func(parameter), TaskCreationOptions.LongRunning);
                task.ContinueWith(asyncPartTask => onException(asyncPartTask.Exception), CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, scheduler);
                task.ContinueWith(asyncPart =>
                {
                    if (!token.IsCancellationRequested)
                        completition();
                },
                                  CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, scheduler);
                task.Start();
    
                return cts;
            }
    
            public static void ExecuteBlockingOperation(Action action, Action completition, Func<bool> shouldComplete, Action<AggregateException> onException)
            {
                if (action == null)
                    throw new ArgumentNullException("action");
    
                if (completition == null)
                    throw new ArgumentNullException("completition");
    
                var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
    
                var task = new Task(action, TaskCreationOptions.LongRunning);
                task.ContinueWith(asyncPartTask => onException(asyncPartTask.Exception), CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, scheduler);
                task.ContinueWith(asyncPart =>
                                      {
                                          if (shouldComplete == null || shouldComplete())
                                              completition();
                                      },
                                  CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, scheduler);
                task.Start();
            }
    
            public static void ExecuteBlockingOperation<TIn>(Action<TIn> action, TIn parameter, Action<TIn> completition, Predicate<TIn> shouldComplete, Action<AggregateException, TIn> onException)
            {
                if (action == null)
                    throw new ArgumentNullException("action");
    
                if (completition == null)
                    throw new ArgumentNullException("completition");
    
                var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
    
                var task = new Task(() => action(parameter), TaskCreationOptions.LongRunning);
                task.ContinueWith(asyncPartTask => onException(asyncPartTask.Exception, parameter), CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, scheduler);
                task.ContinueWith(asyncPart =>
                                      {
                                          if (shouldComplete == null || shouldComplete(parameter))
                                              completition(parameter);
                                      },
                                  CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, scheduler);
                task.Start();
            }
    
            public static void ExecuteBlockingOperation<TOut>(Func<TOut> func, Action<TOut> completition, Predicate<TOut> shoudComplete, Action<AggregateException> onException)
            {
                if (func == null)
                    throw new ArgumentNullException("func");
    
                if (completition == null)
                    throw new ArgumentNullException("completition");
    
                var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
    
                var task = new Task<TOut>(func, TaskCreationOptions.LongRunning);
                task.ContinueWith(asyncPartTask => onException(asyncPartTask.Exception), CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, scheduler);
                task.ContinueWith(asyncPartTask =>
                                      {
                                          if (shoudComplete == null || shoudComplete(asyncPartTask.Result))
                                              completition(asyncPartTask.Result);
                                      },
                                  CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, scheduler);
                task.Start();
            }
    
            public static void ExecuteBlockingOperation<TIn, TOut>(Func<TIn, TOut> func, TIn parameter, Action<TOut, TIn> completition, Func<TOut, TIn, bool> shouldComplete, Action<AggregateException, TIn> onException)
            {
                if (func == null)
                    throw new ArgumentNullException("func");
    
                if (completition == null)
                    throw new ArgumentNullException("completition");
    
                var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
    
                var task = new Task<TOut>(() => func(parameter), TaskCreationOptions.LongRunning);
                task.ContinueWith(asyncPartTask => onException(asyncPartTask.Exception, parameter), CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, scheduler); // on Exception
                task.ContinueWith(asyncPart =>
                                      {
                                          if (shouldComplete == null || shouldComplete(asyncPart.Result, parameter))
                                              completition(asyncPart.Result, parameter);
                                      },
                                  CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, scheduler);
                task.Start();
            }            
        }
