    public sealed class InterlockedValue
    {
        private long _myValue;
        private readonly object _syncObj = new object();
        public long ReadValue()
        {
            // reading of value (99.9% case in app) will not use lock-object, 
            // since this is too much overhead in our highly multithreaded app.
            return Interlocked.Read(ref _myValue);
        }
        public bool SetValueIfGreaterThan(long value)
        {
            // sync Exchange access to _myValue, since a secure greater-than comparisons is needed
            lock (_syncObj)
            {
                // greather than condition
                if (value > Interlocked.Read(ref  _myValue))
                {
                    // now we can set value savely to _myValue.
                    Interlocked.Exchange(ref _myValue, value);
                    return true;
                }
                return false;
            }
        }
    }
