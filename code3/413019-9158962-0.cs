        public event SomeEventHandler SomeEvent
        {
            add
            {
                _someEvent += value;
                lock(_objectLock_m)
                {
                    // do critical processing here, e.g. increment count, etc could also use Interlocked class.
                } // End if
            } // End of class
            remove
            {
                _someEvent -= value;
                lock(_objectLock_m)
                {
                    // do critical processing here, e.g. increment count, etc could also use Interlocked class.
                } // End if
            } // End if
        } // End of event
