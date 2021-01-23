    protected void foo_Init(object sender, EventArgs e)
    {
        foo.ItemTemplate = Page.LoadTemplate("~/Controls/MyLayoutTemplate.ascx");
        foo.EditTemplate = Page.LoadTemplate("~/Controls/MyEditTemplate.ascx");
    }
