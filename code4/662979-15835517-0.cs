     static void InvokeIfRequired(Control control, Action action)
     {
        if (control.InvokeRequired)
        {
            control.Invoke(action);
        }
        else
        {
            action.Invoke();
        }
     }
