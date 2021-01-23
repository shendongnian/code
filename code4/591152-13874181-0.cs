    private void ChangeDay(Delegate del, params object[] args)
    {
        if (this.InvokeRequired)
        {
            methodDelegate = del;
            this.BeginInvoke(new VoidDelegate(RouterDelegate), args);
        }
    }
