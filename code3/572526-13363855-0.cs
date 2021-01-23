    public static void DisposeMainParent<T>(this Control control, Action<T> disposal)
        where T : Control
    {
        Control temp = control;
        T mainControl = null;
        for (Control c = control; c != null && mainControl == null; c = c.Parent)
        {
            mainControl = temp as T;
        }
    
        if (mainControl != null)
        {
            disposal(mainControl);
        }
    }
