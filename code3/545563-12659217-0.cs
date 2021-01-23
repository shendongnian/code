    private Control FindControlRecursive(Control ct, string id)
    {
        Control[] c;
        Control ctr;
        if (ct == null)
            c = mDesigner.Controls.Find(id, true);
        else
            c = ct.Controls.Find(id, true);
        foreach (Control child in c)
        {
            if (child.Name == id)
            {
                ctr = child;
                return ctr;
            }
            else
            {
                ctr = FindControlRecursive(child, id);
                if (ctr != null)
                    return ctr;
            }
        }
        return null;
    }
