    public class SomeClass
    {
        private EventHandler _SmartSyncEvent;
    
        public event EventHandler SmartSyncEvent
        {
            add
            {
                if (!(value.Target is ISynchronizeInvoke))
                {
                    throw new ArgumentException();
                }
                _SmartSyncEvent = (EventHandler)Delegate.Combine(_SmartSyncEvent, value);
            }
            remove
            {
                _SmartSyncEvent = (EventHandler)Delegate.Remove(_SmartSyncEvent, value);
            }
        }
    
        public void RaiseMyEvent()
        {
            foreach (EventHandler handler in _SmartSyncEvent.GetInvocationList())
            {
                var capture = handler;
                var synchronizingObject = (ISynchronizeInvoke)handler.Target;
                synchronizingObject.Invoke(
                    (Action)(() =>
                    {
                        capture(this, new EventArgs());
                    }), null);
            }
        }
    }
