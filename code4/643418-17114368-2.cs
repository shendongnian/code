    public static void InvokeIfRequired(this Control control, Action action)
    {
        try
        {
            if (control.IsDisposed)
                return;
            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }
        catch (ObjectDisposedException)
        {
            // There is nothing much we can do when an Invoke is pending on a disposed control 
            // the other exceptions will bubble up normally
        }
    }
