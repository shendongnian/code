    public static void ForAllChildren(Action<Control> action, 
        params Control[] parents)
    {
        foreach(var p in parents)
            foreach(Control c in p.Controls)
                action(c);
    }
