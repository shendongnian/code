    interface IHandlableObservable<T>
    {
        //gets first chance at the notification
        IDisposable SubscribeFirst(IHandlingObserver<T> observer);
        //gets last chance at the notification
        IDisposable SubscribeLast(IHandlingObserver<T> observer);
        //starts the notification (possibly subscribing to an underlying IObservable)
        IDisposable Connect();
    }
    interface IHandlingObserver<T>
    {
        //return indicates if the observer "handled" the value
        bool OnNext(T value);
        void OnError(Exception ex);
        void OnCompleted();
    }
