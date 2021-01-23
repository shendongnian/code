    public static WebUserControl FindControlRecursive(this WebUserControl source, string name) 
    {
        if (source.ID.Equals(name, StringComparison.Ordinal))
            return source;
        if (!source.Controls.Any()) return null;
        if (source.Controls.Any(x => x.ID.Equals(name, StringComparison.Ordinal))
            return source.FindControl(name);
        WebUserControl result = null;
        // If it falls through to this point then it 
        // didn't find it at the current level
        foreach(WebUserControl ctrl in source.Controls)
        {
            result = ctrl.FindControlRecursive(name);
            if (result != null) 
                return result;
        }
        // If it falls through to this point it didn't find it
        return null;
    }
