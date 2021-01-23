    public static IEnumerable<Control> GetChildControls(this Control control)
    {
        var children = (control.Controls != null) ? control.Controls.OfType<Control>() : Enumerable.Empty<Control>();
        return children.SelectMany(c => GetChildControls(c)).Concat(children);
    }
