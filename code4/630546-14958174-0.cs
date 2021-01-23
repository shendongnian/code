    public class NpcBase
    {
        // Derived classes to call this when starting an async operation
        public Task BeginTask()
        {
            // Task already running?
            if (_result != null)
            {
                throw new InvalidOperationException("busy");
            }
            // Create the async Task
            return Task.Factory.FromAsync(
                // begin method
                (ac, o) =>
                {
                    return _result = new Result(ac, o);
                },
                // End method
                (r) =>
                {
                },
                // State object
                null
                );
        }
        // Derived class calls this when async operation complete
        public void EndTask()
        {
            if (_result != null)
            {
                var temp = _result;
                _result = null;
                temp.Finish();
            }
        }
        // Is this NPC currently busy?
        public bool IsBusy
        {
            get
            {
                return _result != null;
            }
        }
        // Result object for the current task
        private Result _result;
        // Simple AsyncResult class that stores the callback and the state object
        class Result : IAsyncResult
        {
            public Result(AsyncCallback callback, object AsyncState)
            {
                _callback = callback;
                _state = AsyncState;
            }
            private AsyncCallback _callback;
            private object _state;
            public object AsyncState
            {
                get { return _state; ; }
            }
            public System.Threading.WaitHandle AsyncWaitHandle
            {
                get { throw new NotImplementedException(); }
            }
            public bool CompletedSynchronously
            {
                get { return false; }
            }
            public bool IsCompleted
            {
                get { return _finished; }
            }
            public void Finish()
            {
                _finished = true;
                if (_callback != null)
                    _callback(this);
            }
            bool _finished;
        }
    }
