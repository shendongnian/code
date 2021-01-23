    protected override object SaveViewState()
    {
        var a = this.ControlsList;
        var b = base.SaveViewState();
        if (a.Count == 0 && b == null)
            return null;
    
        return new System.Web.UI.Pair(a, b);
    }
    
    protected override void LoadViewState(object savedState)
    {
        if (savedState == null)
            return;
    
        var pair = (System.Web.UI.Pair)savedState;
        if (pair.First != null)
        {
            foreach (var id in (IList<string>)pair.First)
            {
                // add the control
            }
        }
    
        if (pair.Second != null)
            base.LoadViewState(pair.Second);
    }
