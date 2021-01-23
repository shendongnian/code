    public static List<Control> GetAllControlsRecurs(List<Control> list, 
                                                     Control parent)
    {
        if (parent == null)
            return list;
        else
        {
            list.Add(parent);
        }
        foreach (Control child in parent.Controls)
        {
            GetAllControlsRecurs(list, child);
        }
        return list;
    }
