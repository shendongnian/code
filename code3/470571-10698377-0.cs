    Type t = Ctrl.GetType();
    PropertyInfo p = t.GetProperty("Content");
    if (p != null)
    {
        string val = p.GetValue(Ctrl, null) ?? "";
        val = val.Replace("_", "");
        p.SetValue(Ctrl, val, null);
    }
