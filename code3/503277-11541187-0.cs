    private TinyMCE _tinymce = null;
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.ID = "crte";
        DataTypeDefinition d = DataTypeDefinition.GetDataTypeDefinition(-87);
        _tinymce = d.DataType.DataEditor as TinyMCE;
        ConditionalRTEControls.Controls.Add(_tinymce);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        TabView tabView = Page.FindControl("TabView1", true) as TabView;
        TabPage tabPage = GetCurrentTab(ConditionalRTEControls, tabView);
        tabPage.Menu.NewElement("div", "umbTinymceMenu_" + _tinymce.ClientID, "tinymceMenuBar", 0);
    }
    private TabPage GetCurrentTab(Control control, TabView tabView)
    {
        return control.FindAncestor(c => tabView.Controls.Cast<Control>().Any(t => t.ID == c.ID)) as TabPage;
    }
