    public static void InvokeIfNecessary(this Control control,
                                         MethodInvoker action)
    {
        if (control.InvokeRequired)
        {
            control.Invoke(action, null);
        }
        else
        {
            action();
        }
    }
