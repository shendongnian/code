        private int LongRunningMethod(Action<string> error)
        {
            int x = 0;
            try
            {
                x = 20 / x;
            }
            catch (Exception ex)
            {
                error("Bad error!");
            }
            return x;
        }
        public class CommandAndCallback<TCallback, TError>
        {
            public TCallback Callback { get; set; }
            public TError Error { get; set; }
            public Func<Action<string>, int> Delegate { get; set; }
        }
        public void DoOperation(Action<int> callback, Action<string> error)
        {
            Func<Action<string>, int> dlgt = LongRunningMethod;
            CommandAndCallback<Action<int>, Action<string>> callbacks = new CommandAndCallback<Action<int>, Action<string>>() { Callback = callback, Error = error, Delegate=dlgt };
            IAsyncResult ar = dlgt.BeginInvoke(error,MyAsyncCallback, callbacks); 
        }
        public void MyAsyncCallback(IAsyncResult ar)
        {
            int s ;
            CommandAndCallback<Action<int>, Action<string>> callbacks= (CommandAndCallback<Action<int>, Action<string>>)ar.AsyncState;
            s = callbacks.Delegate.EndInvoke(ar);
            callbacks.Success(s);
        }
