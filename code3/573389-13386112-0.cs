    public IEnumerable<TControl> FindControls<TControl>(Control c)
    {
        var tc = c as TControl;
        if (tc != null)
            yield return tc;
    
        foreach (var cc in c.Controls)
        {
            foreach (var res in FindControls<TControl>(cc))
                yield return res;
        }
    }
