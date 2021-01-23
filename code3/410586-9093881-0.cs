    public class EventProxy : Control, IPostBackEventHandler
    {
        public EventProxy()
        { }
        public void RaisePostBackEvent(string eventArgument)
        { }
        public event EventHandler<EventArgs> EventProxied;
        protected virtual void OnEventProxy(EventArgs e)
        {
            if (this.EventProxied != null)
            {
                this.EventProxied(this, e);
            }
        }
        public void ProxyEvent(EventArgs e)
        {
            OnEventProxy(e);
        }
    }
