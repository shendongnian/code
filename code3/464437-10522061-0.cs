    public static void Invoke(this Control control, Action action)
    {
        if (control.InvokeRequired)
        {
            control.Invoke(action);
            return;
        }
    
        action();
    }
    
    public static T Invoke<T>(this Control control, Func<T> action)
    {
        if (control.InvokeRequired)
            return (T)control.Invoke(action);
    
        return action();
    }
