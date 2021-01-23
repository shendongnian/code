    internal class MyOwnedSafeHandleA : MySafeHandleA
    {
        protected override bool ReleaseHandle()
        {
            releaseHandleToA(handle);
            return true;
        }
    }
    internal class MySafeHandleA : SafeHandle
    {
        private int refCountIncremented;
        internal void IncrementRefCount(Action<MySafeHandleA> nativeIncrement)
        {
            nativeIncrement(this);
            refCountIncremented++;
        }
        protected override bool ReleaseHandle()
        {
            while (refCountIncremented > 0)
            {
                releaseHandleToA(handle);
                refCountIncremented--;
            }
            return true;
        }
    }
