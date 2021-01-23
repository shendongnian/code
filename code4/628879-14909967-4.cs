    public class Observer<T> : IObserver<T>
    {
        public void OnCompleted()
        {
        }
    
        public void OnError(Exception error)
        {
            // Do something with exception
        }
    
        public void OnNext(T value)
        {
        }
    }
