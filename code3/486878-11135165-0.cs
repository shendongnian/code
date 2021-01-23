    protected override void OnPreRender(EventArgs e)
    {
        ScriptManager currentScriptManager = ScriptManager.GetCurrent(this.Page);
        if (currentScriptManager != null)
        {
            ScriptReference scriptRef = new ScriptReference("~/js/jquery-ui.js");
            currentScriptManager.Scripts.Add(scriptRef);
        }
        else
        {
            this.Page.ClientScript.RegisterClientScriptInclude(
                this.GetType(), "jquery-ui", "js/jquery-ui.js");
        }
        base.OnPreRender(e);
    }
