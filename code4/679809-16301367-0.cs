    if(control.IsDisposed || !control.IsHandleCreated)
    {
        // some exceptional condition:
        // handle in whatever way is appropriate for your app
        return;
    }
    if(control.InvokeRequired)
    {
        control.Invoke(action);
    }
    else
    {
        action();
    }
