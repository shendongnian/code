    public class NpcBase
    {
        // Derived classes to call this when starting an async operation
        public Task BeginTask()
        {
            // Task already running?
            if (_tcs!= null)
            {
                throw new InvalidOperationException("busy");
            }
            _tcs = new TaskCompletionSource<int>();
            return _tcs.Task;
        }
        TaskCompletionSource<int> _tcs;
        // Derived class calls this when async operation complete
        public void EndTask()
        {
            if (_tcs != null)
            {
                var temp = _tcs;
                _tcs = null;
                temp.SetResult(0);
            }
        }
        // Is this NPC currently busy?
        public bool IsBusy
        {
            get
            {
                return _tcs != null;
            }
        }
    }
