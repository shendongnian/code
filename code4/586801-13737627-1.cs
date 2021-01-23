    public static IEnumerable<Control> FindControl(this Control control)
    {
        var children = control.Controls.Cast<Control>();
        return children.SelectMany(c => FindControl(c)).Concat(children);
    }
