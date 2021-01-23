    public static void AttachButtonLogging(Control.ControlCollection controls)
    {
        foreach (var control in controls.Cast<Control>())
        {
            if (control is Button)
            {
               Button button = (Button)control;
               button.Click += LogButtonClick;
            }
            else
            {
                AttachButtonLogging(control.Controls);
            }
        }
    }
