        public class WrapperClass
        {
            private EventHandler<SocketAsyncEventArgs> _myEvent;
            private SocketAsyncEventArgs _myvm;
            private List<Delegate> delegates;
    
            public WrapperClass()
            {
                delegates = new List<Delegate>();
            }
    
            public void SetInstance(SocketAsyncEventArgs myvm)
            {
                _myvm = myvm;
                _myvm.Completed += new EventHandler<SocketAsyncEventArgs>(_instance_Completed);
            }
    
            private void _instance_Completed(object sender, SocketAsyncEventArgs e)
            {
                if (_myEvent != null)
                {
                    _myEvent(sender, e);
                }
            }
    
            public event EventHandler<SocketAsyncEventArgs> myEvent
            {
                add
                {
                    delegates.Add(value);
                    _myEvent = (EventHandler<SocketAsyncEventArgs>)Delegate.Combine(_myEvent, value);
                }
                remove
                {
                    delegates.Remove(value);
                    _myEvent = (EventHandler<SocketAsyncEventArgs>)Delegate.Remove(_myEvent, value);
                }
            }
    
            public void ClearEvents()
            {
                foreach (var d in delegates)
                {
                _myEvent = (EventHandler<SocketAsyncEventArgs>)Delegate.Remove(_myEvent, d);
                }
            }
        }
