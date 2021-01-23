    public static void Invoke<T>(this T c, Action<T> action) where T : Control
    {
        if (c.InvokeRequired)
            c.TopLevelControl.Invoke(action);
        else
            action(c);
    }
