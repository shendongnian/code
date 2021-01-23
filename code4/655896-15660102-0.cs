    public class JobProcessor<T> : IDisposable where T : new()
    {
        private ISubject<Action<T>> jobsProcessor = new Subject<Action<T>>();
        private IDisposable disposer;
        private T _jobProvider = new T();
        public JobProcessor(Func<ISubject<Action<T>>, IObservable<IEnumerable<Action<T>>>> initializer)
        {
            Console.WriteLine("Entering JobProcessor Constructor");
            disposer = initializer(jobsProcessor)
                .Subscribe(OnJobsNext, OnJobsError, OnJobsComplete);
            Console.WriteLine("Leaving JobProcessor Constructor");
        }
        private void OnJobsNext(IEnumerable<Action<T>> actions)
        {
            Debug.WriteLine("Entering OnJobsNext");
            foreach (var action in actions)
            {
                action(_jobProvider);
            }
            Debug.WriteLine("Leaving OnJobsNext");
        }
        private void OnJobsError(Exception ex)
        {
            Debug.WriteLine("Entering OnJobsError");
            Debug.WriteLine(ex.Message);
            Debug.WriteLine("Leaving OnJobsError");
        }
        private void OnJobsComplete()
        {
            Debug.WriteLine("Entering OnJobsComplete");
            Debug.WriteLine("Leaving OnJobsComplete");
        }
        public void QueueJob(Action<T> action)
        {
            Debug.WriteLine("Entering QueueJobs");
            jobsProcessor.OnNext(action);
            Debug.WriteLine("Leaving QueueJobs");
        }
        public void Dispose()
        {
            disposer.Dispose();
        }
    }
