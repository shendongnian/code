    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        this.Page.ClientScript.RegisterClientScriptInclude(
            typeof(YourUserControl), "FusionCharts", "Charts/FusionCharts.js");
    }
