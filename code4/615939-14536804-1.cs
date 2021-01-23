    public static void ProcessAllControls<T>(Control rootControl, Action<Control> action)where T:Control
    {
        foreach (Control childControl in rootControl.Controls.OfType<T>())
        {
            action(childControl);
        }
        foreach (Control childControl in rootControl.Controls)
        {
            ProcessAllControls<T>(childControl, action);
        }
    }
