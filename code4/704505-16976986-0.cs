    public static Control FindFocusedControl(Control control)
    {
        var container = control as ContainerControl;
        while (container != null)
        {
            control = container.ActiveControl;
            container = control as ContainerControl;
        }
        return control;
    }
