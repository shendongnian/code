    public static void ProcessAllControls(Control rootControl, Action<Control> action)
    {
        foreach (Control childControl in rootControl.Controls)
        {
            ProcessAllControls(childControl, action);
            action(childControl);
        }
    }
