    private Panel _TitleBarPanel;
    private Panel _ActionBarPanel;
    protected override void CreateChildControls()
    {
        _TitleBarPanel = new Panel { CssClass = "titleBar" };
        _TitleBarTemplateValue.InstantiateIn(_TitleBarPanel);
        this.Controls.Add(_TitleBarPanel);
        _ActionBarPanel = new Panel { CssClass = "actionBar" };
        _ActionBarTemplateValue.InstantiateIn(_ActionBarPanel);
        this.Controls.Add(_ActionBarPanel);
    }
