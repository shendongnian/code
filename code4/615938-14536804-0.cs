    private void ProcessAllControls<T>(Control rootControl, Action<Control> action)where T:Control
    {
        foreach (Control childControl in rootControl.Controls.OfType<T>())
        {
            ProcessAllControls<T>(childControl, action);
            action(childControl);
        }
    }
