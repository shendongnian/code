    public static Control TopMostParent(this Control control)
    {
        var parent = control.Parent;
        while (parent.Parent != null)
        {
            parent = parent.Parent;
        }
        return parent;
    } 
