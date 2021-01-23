    public static class BlockingCollectionExtensions
    {
        // TODO: devise a way to avoid problems if collection gets too big (produced faster than consumed)
        public static IObservable<T> AsRateLimitedObservable<T>(this BlockingCollection<T> sequence, int items, TimeSpan timePeriod, CancellationToken producerToken)
        {
            Subject<T> subject = new Subject<T>();
            // this is a dummyToken just so we can recreate the TokenSource
            // which we will pass the proxy class so it can cancel the task
            // on disposal
            CancellationToken dummyToken = new CancellationToken();
            CancellationTokenSource tokenSource = CancellationTokenSource.CreateLinkedTokenSource(producerToken, dummyToken);
            var consumingTask = new Task(() =>
            {
                using (var throttle = new Throttle(items, timePeriod))
                {
                    while (!sequence.IsCompleted)
                    {
                        try
                        {
                            T item = sequence.Take(producerToken);
                            throttle.WaitToProceed();
                            try
                            {
                                subject.OnNext(item);
                            }
                            catch (Exception ex)
                            {
                                subject.OnError(ex);
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            break;
                        }
                    }
                    subject.OnCompleted();
                }
            }, TaskCreationOptions.LongRunning);
            return new TaskAwareObservable<T>(subject, consumingTask, tokenSource);
        }
        private class TaskAwareObservable<T> : IObservable<T>, IDisposable
        {
            private readonly Task task;
            private readonly Subject<T> subject;
            private readonly CancellationTokenSource taskCancellationTokenSource;
            public TaskAwareObservable(Subject<T> subject, Task task, CancellationTokenSource tokenSource)
            {
                this.task = task;
                this.subject = subject;
                this.taskCancellationTokenSource = tokenSource;
            }
            public IDisposable Subscribe(IObserver<T> observer)
            {
                var disposable = subject.Subscribe(observer);
                if (task.Status == TaskStatus.Created)
                    task.Start();
                return disposable;
            }
            public void Dispose()
            {
                // cancel consumption and wait task to finish
                taskCancellationTokenSource.Cancel();
                task.Wait();
                // dispose tokenSource and task
                taskCancellationTokenSource.Dispose();
                task.Dispose();
                // dispose subject
                subject.Dispose();
            }
        }
    }
