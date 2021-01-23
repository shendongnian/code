    public static Control FindControlRecursive(Control container, string name)
    {
        if ((container.ID != null) && (container.ID.Equals(name)))
            return container;
     
        foreach (Control ctrl in container.Controls)
        {
            Control foundCtrl = FindControlRecursive(ctrl, name);
            if (foundCtrl != null)
                return foundCtrl;
        }
        return null;
    }
