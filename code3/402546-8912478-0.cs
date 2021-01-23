    public class ActionWaitHandler
    {
        private int _count;
        private readonly Action _callback;
        public ActionWaitHandler(int count, Action callback)
        {
            _count = count;
            _callback = callback;
        }
        public void Signal()
        {
            _count--;
            if (_count == 0)
            {
                _callback();
            }
        }
    }
