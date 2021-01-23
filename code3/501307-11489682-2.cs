    public delegate void RemovedEventHandler(object sender, EventArgs e);
    class ChildControl
    {
        ...
        public event RemovedEventHandler Removed;
        protected virtual void OnRemoved(EventArgs e)
        {
            if (Removed != null)
                Removed(this, e);
        }
        public void Remove(object value) 
        {
           // Before remove from parent call event 
           OnRemoved(EventArgs.Empty);
           //Here remove from parent
           ...
        }
    }
