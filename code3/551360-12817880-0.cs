    protected override void OnLoad(EventArgs e)
    {
        Page.ClientScript.RegisterClientScriptInclude(
            "JQueryInclude",
            "/path/to/your/jquery.js");
        base.OnLoad(e);
    }
