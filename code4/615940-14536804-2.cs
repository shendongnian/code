    private void ProcessAllControls<T>(Control rootControl, Action<T> action)where T:Control
    {
        foreach (T childControl in rootControl.Controls.OfType<T>())
        {
            action(childControl);
        }
        foreach (Control childControl in rootControl.Controls)
        {
            ProcessAllControls<T>(childControl, action);
        }
    }
