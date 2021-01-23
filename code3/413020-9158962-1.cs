        private readonly object _objectLock = new object(); 
        private SomeEventHandler _someEvent; 
        public event SomeEventHandler SomeEvent
        {
            add
            {      
                lock(_objectLock)
                {
                    _someEvent += value;
                    // do critical processing here, e.g. increment count, etc could also use Interlocked class.
                } // End if
            } // End of class
            remove
            {
                lock(_objectLock_m)
                {
                     _someEvent -= value;
                    // do critical processing here, e.g. increment count, etc could also use Interlocked class.
                } // End if
            } // End if
        } // End of event
