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
    }
