    public interface IProgress<T>
    {
        void Report(T data);
    }
    
    public class Progress<T> : IProgress<T>
    {
        SynchronizationContext context;
        public Progress()
        {
            context = SynchronizationContext.Current;
        }
    
        public Progress(Action<T> action)
            : this()
        {
            ProgressReported += action;
        }
    
        public event Action<T> ProgressReported;
    
        void IProgress<T>.Report(T data)
        {
            var action = ProgressReported;
            if (action != null)
            {
                if (context != null)
                    context.Post(obj => action(data), null);
                else
                    ThreadPool.QueueUserWorkItem(obj => action(data));
            }
        }
    }
