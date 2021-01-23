    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Menu.Items.Add(new MenuItem("Tab 1", "0"));
            Menu.Items.Add(new MenuItem("Tab 2", "1"));
            ...
            Menu.Items.Add(new MenuItem("Tab 10", "9"));
        }
    }
