    private class CallbackWrapper<T,T1>
    {
        private Func<T, T1> _action;
        public CallbackWrapper(Func<T, T1> action)
        {
            _action = action;
        }
        public void Callback(IAsyncResult ar)
        {
            IAsyncSubscriber subscriber = (IAsyncSubscriber)ar.AsyncState;
            T1 returnValue = _action.EndInvoke(ar);
            subscriber.Callback(returnValue);
        }
    }
    public static void Execute<T, T1>(IAsyncSubscriber subscriber, T param, Func<T, T1> action)
    {
        action.BeginInvoke(param, new CallbackWrapper<T, T1>(action).Callback, subscriber);
    }
