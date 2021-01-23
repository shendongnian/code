    public class DelegateWorker : IDelegateWorker
    {
        public void Start<TInput, TResult>(Func<TInput, TResult> onStart, Action<TResult> onComplete, TInput parm)
        {
            TResult result = default(TResult);
            if (onStart != null)
                result = onStart(parm);
            if (onComplete != null)
                onComplete(result);
        }
    }
