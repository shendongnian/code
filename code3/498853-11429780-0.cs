    public delegate void ChangedEventHandler(object sender, EventArgs e);
    class TreeViewEx : TreeView
    {
        ...
        public event ChangedEventHandler Changed;
        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }
    }
