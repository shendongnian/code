    public delegate void ClearControl(Control aCtrl);
    private static Dictionary<Type, ClearControl> _clearDelegates;
    public static Dictionary<Type, ClearControl> ClearDelegates
    {
        get 
        { 
            if (_clearDelegates== null)
                InitializeClearDelegates();
            return _clearDelegates; 
        }
    }
    private static void InitializeClearDelegates()
    {
        _clearDelegates= new Dictionary<Type, ClearControl>();
        _clearDelegates[typeof(TextBox)] = new ClearControl(delegate(Control aCtrl) 
        {
            ((TextBox)aCtrl).Text = string.Empty;
        });
        _clearDelegates[typeof(CheckBox)] = new ClearControl(delegate(Control aCtrl)
        {
            ((CheckBox)aCtrl).Checked = false;
        });
        _clearDelegates[typeof(GroupBox)] = new ClearControl(delegate(Control aCtrl)
        {
            foreach (Control innerCtrl in ((GroupBox)aCtrl).Controls)
                Clear(innerCtrl);
        });
        _clearDelegates[typeof(TabPage)] = new ClearControl(delegate(Control aCtrl)
        {
            foreach (Control innerCtrl in ((TabPage)aCtrl).Controls)
                Clear(innerCtrl);
        });
        // ... other controls
    }
    public static object Clear(Control aCtrl)
    {
        ClearControl aDel;
        if (ClearDelegates.TryGetValue(aCtrl.GetType(), out aDel))
            aDel(aCtrl);
    }
