    public class SomeClass
    {
        public event EventHandler SmartSyncEvent;
        public ISynchronizeInvoke SynchronizingObject { get; set; }
    
        public void RaiseSmartSyncEvent()
        {
            if (SynchronizingObject != null)
            {
                SynchronizingObject.Invoke(
                  (Action)(()=>
                  {
                      SmartSyncEvent();
                  }), null);
            }
            else
            {
                SmartSyncEvent();
            }
        }
    }
