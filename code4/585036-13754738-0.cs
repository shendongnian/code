    public class Foobar
    {
        private readonly Object _syncRoot = new Object();
        private object _val;
        private Boolean _isFrozen;
        private Action<object> WriteValInternal;
        public void Freeze() { _isFrozen = true; }
        public Foobar()
        {
            WriteValInternal = BeforeFreeze;
        }
        private void BeforeFreeze(object val)
        {
            lock (_syncRoot)
            {
                if (_isFrozen == false)
                {
                    //Write the values....
                    _val = val;
                    //...
                    //...
                    //...
                    //and then modify the write value function
                    WriteValInternal = AfterFreeze;
                    Freeze();
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }
        private void AfterFreeze(object val)
        {
            throw new InvalidOperationException();
        }
        public void WriteValue(Object val)
        {
            WriteValInternal(val);
        }
        public Object ReadSomething()
        {
            return _val;
        }
    }
