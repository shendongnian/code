    public class ASyncDelegateWorker : IDelegateWorker
    {
        public void Start<TInput, TResult>(Func<TInput, TResult> onStart, Action<TResult> onComplete, TInput parm)
        {
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += (s, e) =>
            {
                if (onStart != null)
                    e.Result = onStart((TInput)e.Argument);
            };
            bg.RunWorkerCompleted += (s, e) =>
            {
                if (onComplete != null)
                    onComplete((TResult)e.Result);
            };
            bg.RunWorkerAsync(parm);
        }
    }
