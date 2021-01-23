    public class HandleManager
    {
        private int _lastHandle;
        private readonly HashSet<int> _handlesInUse = new HashSet<int>();
        // "Pool" of free handles.
        private readonly Queue<int> _freeHandles = new Queue<int>();
        public int GetHandle()
        {
            int handle = _freeHandles.Count > 0 ? _freeHandles.Dequeue() : _lastHandle++;
            _handlesInUse.Add(handle);
            return handle;
        }
        public void Release(int handle)
        {
            if (!_handlesInUse.Remove(handle))
                throw new ArgumentException("Handle is not in use", "handle");
            _freeHandles.Enqueue(handle);
        }
    }
