    private Control RecursiveFindControl(Control root, string id)
    {
        if (root.ID == id) return root;
        foreach (Control c in root.Controls)
        {
            Control t = RecursiveFindControl(c, id);
            if (t != null) return t;
        }
        return null;
    }
