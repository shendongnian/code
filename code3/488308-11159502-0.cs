    public class publisher
    {
        
        public event EventHandler<EventArgs> TestEvent;
        protected virtual void OnTestEvent(EventArgs e)
        {
            EventHandler<EventArgs> temp = Interlocked.CompareExchange(ref TestEvent, null, null);
            if (temp != null)
                temp(this,e);
        }
    }
