    protected override ControlCollection CreateControlCollection()
    {
        CurrentScriptManager = BuildScriptManager();
        ControlCollection pageControls = base.CreateControlCollection();
        pageControls.AddAt(0, CurrentScriptManager);
        return pageControls;
    }
    protected override void OnInit(EventArgs e)
    {
        Form.Controls.AddAt(0, CurrentScriptManager);
        base.OnInit(e);
    }
