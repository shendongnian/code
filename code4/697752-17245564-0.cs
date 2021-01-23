    public void InjectScriptResource(dynamic window)
    {
        var windowEx = (IExpando)window;
        if (windowEx.GetProperty("signJson", BindingFlags.Default) == null)
        {
            // windowEx.AddProperty("signJson");
            PropertyInfo p = windowEx.AddProperty("signJson");
            // window.signJson = this;
            p.SetValue(windowEx, this);
        }
    }
