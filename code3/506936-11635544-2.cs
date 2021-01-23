    public static Control FindControl(this Control parent, string name)
    {
        if (parent == null || string.IsNullOrEmpty(name))
        {
            return null;
        }
        Control[] controls = parent.Controls.Find(name, true);
        if (controls.Length > 0)
        {
            return controls[0];
        }
        else
        {
            return null;
        }
    }
    public static T FindControl<T>(this Control parent, string name) where T : class
    {
        if (parent == null || string.IsNullOrEmpty(name))
        {
            return null;
        }
        Control[] controls = parent.Controls.Find(name, true);
        foreach (Control c in controls)
        {
            if (c is T)
            {
                return c as T;
            }
        }
        return null;
    }
